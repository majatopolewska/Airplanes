using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using NetworkSourceSimulator;

namespace airplanes
{
    class wewillsee
    {
        private static List<IAviationObject> data;
        //private static FlightsGUIData flightsGUIData; // Observer data
        private static readonly object dataLock = new object();

        private static Dictionary<ulong, Airport> allAirports = new Dictionary<ulong, Airport>();

        public static void LoadData()
        {
            //data = new List<IAviationObject>();

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

        // Method to convert aviation data to FlightsGUIData format
        private static FlightsGUIData ConvertToFlightsGUIData(List<IAviationObject> aviationData)
        {
            List<FlightGUI> flightsData = new List<FlightGUI>();
            
            foreach (var aviationObject in aviationData)
            {
                if (aviationObject is Flight flight)
                {
                    WorldPosition worldPos = new WorldPosition(flight.Longitude, flight.Latitude);

                    Airport originAirport = allAirports[flight.OriginId];
                    Airport targetAirport = allAirports[flight.TargetId];

                    double angleDegrees = Airport.CalculateAngle(originAirport, targetAirport);

                    FlightGUI flightGUI = new FlightGUI() { ID = flight.Id, WorldPosition = worldPos, MapCoordRotation = 0 };
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
            UpdateFlights();
        }
    }
}
