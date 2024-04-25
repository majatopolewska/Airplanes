using Newtonsoft.Json;
using static airplanes.UpdateData;


namespace airplanes
{
    class Program
    {
        static void Main(string[] args)
        {
            // exirt caly proogram
            LoadDataSource lds = new();
            lds.LoadDatafromSource();
            //Reporting();
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

    }
}