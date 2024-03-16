using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NetworkSourceSimulator;

namespace airplanes
{
    public class LoadDataSource
    {
        private static List<IAviationObject> data;
        private static readonly object dataLock = new object(); 

        public static void LoadDatafromSource()
        {
            data = new List<IAviationObject>();

            string inputFile = "data.ftr";

            string currentDirectory = Directory.GetCurrentDirectory();
            string inputFilePath = Path.Combine(currentDirectory, inputFile);

            NetworkSourceSimulator.NetworkSourceSimulator dataSource = new NetworkSourceSimulator.NetworkSourceSimulator(inputFilePath, 100, 100);

            dataSource.OnNewDataReady += DataSource_OnNewDataReady;

            Thread dataSourceThread = new Thread(dataSource.Run);
            dataSourceThread.IsBackground = true;
            dataSourceThread.Start();

            Console.WriteLine("print - do a snapshot");

            bool exitCommand = false;

            while (!exitCommand)
            {
                string command = Console.ReadLine();
                switch (command)
                {
                    case "print":
                        string outputFile = $"snapshot_{DateTime.Now.Hour:D2}_{DateTime.Now.Minute:D2}_{DateTime.Now.Second:D2}.json";
                        string outputFilePath = Path.Combine(currentDirectory, outputFile);
                        Program.SaveToJson(data.ToArray(), outputFilePath);
                        break;
                    case "exit":
                        exitCommand = true;
                        break;
                    default:
                        break;
                }
            }

            dataSource.OnNewDataReady -= DataSource_OnNewDataReady;
        }

        // Message handler
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
        }
    }
}
