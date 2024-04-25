using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Reflection.PortableExecutable;
using System.Runtime.InteropServices;
using System.Xml;
using Newtonsoft.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;
using NetworkSourceSimulator;
using static airplanes.UpdateData;
using static airplanes.Report;
using static airplanes.LoadDataSource;

namespace airplanes
{
    class Program
    {
        static void Main(string[] args)
        {
            LoadDatafromSource();
            Reporting();
            ShowMap();
        }

        public static T FormatData<T>(string data)
        {
            string temp = data.ToString(System.Globalization.CultureInfo.InvariantCulture);
            T result = (T)Convert.ChangeType(temp, typeof(T), System.Globalization.CultureInfo.InvariantCulture);
            return result;
        }
        public static void SaveToJson(object[] data, string filePath)
        {
            var json = JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

        public static void ShowMap()
        {
            LoadData();
            GetAirports();

            Thread guiThread = new Thread(FlightTrackerGUI.Runner.Run);
            guiThread.Start();

            Console.WriteLine("Compiling...");
            Thread.Sleep(1000);

            RunUpdateFlights();
        }
        private static void RunUpdateFlights()
        {
            while (true)
            {
                UpdateFlights();
                Thread.Sleep(1000);
            }
        }

        public static void Reporting()
        {
            bool entered = false;
            while (!entered)
            {
                string command = Console.ReadLine();
                switch (command)
                {
                    case "report":
                        DoingReport();
                        entered = true;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}