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
        private static FlightsGUIData flightsGUIData; // Observer data
        private static readonly object dataLock = new object();

        private static Dictionary<ulong, Airport> allAirports;

        public static void LoadDatafromSource()
        {
            data = new List<IAviationObject>();

            string inputFile = "data.ftr";
            string currentDirectory = Directory.GetCurrentDirectory();
            string inputFilePath = Path.Combine(currentDirectory, inputFile);

            NetworkSourceSimulator.NetworkSourceSimulator dataSource = new NetworkSourceSimulator.NetworkSourceSimulator(inputFilePath, 100, 100);

            // Subscribe to data source event
            dataSource.OnNewDataReady += DataSource_OnNewDataReady;

            Thread dataSourceThread = new Thread(dataSource.Run);
            dataSourceThread.IsBackground = true;
            dataSourceThread.Start();

            // Unsubscribe from data source event (no longer needed)
            dataSource.OnNewDataReady -= DataSource_OnNewDataReady;
        }

        // Data source event handler
        private static void DataSource_OnNewDataReady(object sender, NewDataReadyArgs args)
        {
            Message message = ((NetworkSourceSimulator.NetworkSourceSimulator)sender).GetMessageAt(args.MessageIndex);
            var str = System.Text.Encoding.Default.GetString(message.MessageBytes);

            MessageParser messageP = new MessageParser();
            IAviationObject resultObject = messageP.GetDataFromMessage(message.MessageBytes);

            lock (dataLock)
            {
                data.Add(resultObject);
            }

            // Notify observers when new data is ready
            UpdateObservers();
        }

        // Method to notify observers (GUI) about the new data
        private static void UpdateObservers()
        {
            // Convert aviation data to GUI-friendly format
            flightsGUIData = ConvertToFlightsGUIData(data);

            // Notify GUI with the updated data
            FlightTrackerGUI.Runner.UpdateGUI(flightsGUIData);
        }

        // Method to convert aviation data to FlightsGUIData format
        private static FlightsGUIData ConvertToFlightsGUIData(List<IAviationObject> aviationData)
        {
            List<FlightGUI> flightsData = new List<FlightGUI>();
            double angleDegrees = 0;

            foreach (var aviationObject in aviationData)
            {
                if (aviationObject is Flight flight)
                {
                    WorldPosition worldPos = new WorldPosition(flight.Longitude, flight.Latitude);

                    Airport originAirport = allAirports.GetValueOrDefault(flight.OriginId);
                    Airport targetAirport = allAirports.GetValueOrDefault(flight.TargetId);

                    if (originAirport != null && targetAirport != null)
                    {
                        angleDegrees = originAirport.CalculateAngle(originAirport, targetAirport);
                    }
                    else
                    {
                        Console.WriteLine("Origin or target airport not found.");
                    }

                    FlightGUI flightGUI = new FlightGUI() { ID = flight.Id, WorldPosition = worldPos, MapCoordRotation = angleDegrees };
                    flightsData.Add(flightGUI);
                }
            }

            return new FlightsGUIData(flightsData);
        }

        public static void ShowMap()
        {
            FlightTrackerGUI.Runner.Run();
        }
    }
}
