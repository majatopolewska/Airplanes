using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetworkSourceSimulator;

namespace airplanes
{
    public class LoadDataSource
    {
        public static void LoadDatafromSource()
        {
            string inputFile = "data.ftr";
            string currentDirectory = Directory.GetCurrentDirectory();
            string inputFilePath = Path.Combine(currentDirectory, inputFile);

            NetworkSourceSimulator.NetworkSourceSimulator dataSource = new NetworkSourceSimulator.NetworkSourceSimulator(inputFilePath, 100, 1000);

            dataSource.OnNewDataReady += DataSource_OnNewDataReady;
            //ParameterizedThreadStart startit = dataSource;
           
            Thread dataSourceThread = new Thread(dataSource.Run);
            dataSourceThread.Start();

            Console.WriteLine("Press any key to exit."); // switch z print i exit
            // użyć serializacji z poprzedniego etapu - funkcja SaveToJson
            Console.ReadKey();

            dataSourceThread.Abort();
        }


        // message handler
        private static void DataSource_OnNewDataReady(object sender, NewDataReadyArgs args)
        {
            // to message w bajtach
            // wojtek by zrobił tak
            // w tej klasie lista obiektów
            // i w handlerze odpalasz funckcje która to parsuje - factory
            // i dodajesz do listy obiekt który to factory zwróci
            // tip od Wojtka - Dependencies - Assemblies - SZUKAJ

            //PRZYDATNE FUNKCJE
            // bitconverter.Totypzmiennej
            // encoding.ascii.getstring
            // datetimeoffset.fromunixtimemiliseconds

            Message message = ((NetworkSourceSimulator.NetworkSourceSimulator) sender).GetMessageAt(args.MessageIndex);
            var str = System.Text.Encoding.Default.GetString(message.MessageBytes);
            Console.WriteLine(str);
            Console.WriteLine("New message received. Message index: " + args.MessageIndex);

            
            // TU PARSOWANIE
        }
    }
}