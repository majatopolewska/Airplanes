using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Threading;
using Avalonia;
using Avalonia.Rendering;
using Mapsui.Projections;
using NetworkSourceSimulator;

namespace airplanes
{
    class wewillsee
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
        private static void UpdateFlights()
        {
            FlightsGUIData flightsGUIData = ConvertToFlightsGUIData(data);

            FlightTrackerGUI.Runner.UpdateGUI(flightsGUIData);
        }

        private static void GetAirports()
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
            TimeSpan flightDuration = flight.CalculateFlightTime();

            (double x, double y) distanceOfFlight = Airport.CalculateDistance(origin, target);
            (double origin_x, double origin_y) = SphericalMercator.FromLonLat(origin.Longitude, origin.Latitude);

            double moveForSecondinX = distanceOfFlight.x / flightDuration.TotalSeconds;
            double moveForSecondinY = distanceOfFlight.y / flightDuration.TotalSeconds;

            DateTime takeoff = DateTime.Parse(flight.TakeoffTime);

            TimeSpan timeFromStart = DateTime.Now - takeoff;

            WorldPosition currPosition = new WorldPosition();
            currPosition.Longitude = origin_x + moveForSecondinX * timeFromStart.TotalSeconds;
            currPosition.Latitude = origin_y + moveForSecondinY * timeFromStart.TotalSeconds;

            return currPosition;
        }
        

        // Method to convert aviation data to FlightsGUIData format
        private static FlightsGUIData ConvertToFlightsGUIData(List<IAviationObject> aviationData)
        {
            List<FlightGUI> flightsData = new List<FlightGUI>();
            
            foreach (var aviationObject in aviationData)
            {
                if (aviationObject is Flight flight)
                {
                    Airport originAirport = allAirports[flight.OriginId];
                    Airport targetAirport = allAirports[flight.TargetId];

                    double angleDegrees = Airport.CalculateAngle(originAirport, targetAirport);

                    WorldPosition currentPosition = CalculateCurrentPosition(flight, originAirport, targetAirport);

                    FlightGUI flightGUI = new FlightGUI() { ID = flight.Id, WorldPosition = currentPosition, MapCoordRotation = 0 };
                    flightsData.Add(flightGUI);
                }
            }

            return new FlightsGUIData(flightsData);
        }

        public static void ShowMap()
        {
            LoadData();
            GetAirports();
            UpdateFlights();
            FlightTrackerGUI.Runner.Run();

            Thread dataSourceThread = new Thread(RunUpdateFlights);
            dataSourceThread.IsBackground = true;
            dataSourceThread.Start();
        }
        private static void RunUpdateFlights()
        {
            while (true)
            {
                UpdateFlights();
                Thread.Sleep(1000);
            }
        }
    }
}
