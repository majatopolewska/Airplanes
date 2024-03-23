using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Threading;
using Avalonia;
using Avalonia.Markup.Xaml.MarkupExtensions;
using Avalonia.Rendering;
using Mapsui.Projections;
using NetworkSourceSimulator;

namespace airplanes
{
    class UpdateData
    {
        private static List<IAviationObject> data;
        private static readonly object dataLock = new object();

        private static Dictionary<ulong, Airport> allAirports = new Dictionary<ulong, Airport>();

        public static void LoadData()
        {
            string inputFile = "data.ftr";
            string currentDirectory = Directory.GetCurrentDirectory();
            string inputFilePath = Path.Combine(currentDirectory, inputFile);

            data = ReadFile.ReadDataFromFile(inputFile);
        }
        public static void UpdateFlights()
        {
            FlightsGUIData flightsGUIData = ConvertToFlightsGUIData(data);
            Console.WriteLine($"count: {flightsGUIData.GetFlightsCount()}");

            FlightTrackerGUI.Runner.UpdateGUI(flightsGUIData);
        }

        public static void GetAirports()
        {
            foreach (var aviationObject in data)
            {
                if (aviationObject.messageType == "AI")
                {
                    Airport airport = (Airport)aviationObject;

                    allAirports.Add(airport.Id, airport);
                }
            }
        }

        private static WorldPosition CalculateCurrentPosition(Flight flight, Airport origin, Airport target)
        {
            double flightDuration = (flight.CalculateFlightTime()).TotalSeconds;

            (double x, double y) distanceOfFlight = Airport.CalculateDistance(origin, target);
            (double origin_x, double origin_y) = (origin.Longitude, origin.Latitude);

            // PROCENT DROGI OD START DO END

            

            DateTime takeoff = DateTime.Parse(flight.TakeoffTime);
            DateTime landing = DateTime.Parse(flight.LandingTime);

            if (DateTime.Now < takeoff)
            {
                takeoff = takeoff.AddDays(-1);
            }
            double timeFromStart = (DateTime.Now - takeoff).TotalSeconds;

            double t = timeFromStart / flightDuration;
            double travelledDistanceX = distanceOfFlight.x * t;
            double travelledDistanceY = distanceOfFlight.y * t;

            // tu tez moze byc zle przy samolotach landing<takeoff
            // mozna sprawdzic wypisujac wszystkie i liczac reczenie z ftr

            WorldPosition currPosition = new WorldPosition();
            
            currPosition.Longitude = origin_x + travelledDistanceX; //ni chuja tak nie mozna 
            currPosition.Latitude = origin_y + travelledDistanceY; // tak samo
            // odleglosc w (x,y) != odleglosc w (lon,lat)
            // ponizej wypisywanie samolotow dla ktorych sa zle wspolrzedne
            
            if((currPosition.Longitude < -180 || currPosition.Longitude > 180) || (currPosition.Latitude > 90 || currPosition.Latitude < -90))
            {
                DateTime departureTime = DateTime.Parse(flight.TakeoffTime);
                DateTime landingTime = DateTime.Parse(flight.LandingTime);
                if (landingTime < departureTime)
                {
                    departureTime.AddDays(-1);
                }
                if (departureTime <= DateTime.Now && landingTime >= DateTime.Now)
                    Console.WriteLine($"ID {flight.Id} Duration {flightDuration} Lon {currPosition.Longitude} Lat {currPosition.Latitude} {timeFromStart}");

            }

            return currPosition;
        }

        private static FlightsGUIData ConvertToFlightsGUIData(List<IAviationObject> aviationData)
        {
            List<FlightGUI> flightsData = new List<FlightGUI>();
            
            foreach (var aviationObject in aviationData)
            {
                if (aviationObject is Flight flight)
                {
                    Airport originAirport = allAirports[flight.OriginId];
                    Airport targetAirport = allAirports[flight.TargetId];

                    DateTime departureTime = DateTime.Parse(flight.TakeoffTime);
                    DateTime landingTime = DateTime.Parse(flight.LandingTime);
                    if(landingTime < departureTime)
                    {
                        departureTime.AddDays(-1);
                    }
                    if (departureTime <= DateTime.Now && landingTime >= DateTime.Now) // ten if nie da ci wysztkich samolotow
                        // bo co jak departure 23:55 i teraz jest 00:01
                    {
                        double angleRadians = Airport.CalculateAngle(originAirport, targetAirport);

                        WorldPosition currentPosition = CalculateCurrentPosition(flight, originAirport, targetAirport);
                        
                        FlightGUI flightGUI = new FlightGUI() { ID = flight.Id, WorldPosition = currentPosition, MapCoordRotation = angleRadians };
                        flightsData.Add(flightGUI);
                    }
                }
            }

            return new FlightsGUIData(flightsData);
        }
    }
}
