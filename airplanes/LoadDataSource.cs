using NetworkSourceSimulator;
using static airplanes.Report;

namespace airplanes
{
    public class LoadDataSource : ISubject
    {
        private static List<IAviationObject> data;
        private static readonly object dataLock = new object();
        private Logger logger = new();

        // ??
        private List<IObserver> observers = new List<IObserver>();

        public void Attach(IObserver observer)
        {
            observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var observer in observers)
            {
                observer.Update(this);
            }
        }

        // ????
        public void LoadDatafromSource()
        {
            data = new List<IAviationObject>();

            string inputFile = "example.ftre";

            string currentDirectory = Directory.GetCurrentDirectory();
            string inputFilePath = Path.Combine(currentDirectory, inputFile);

            NetworkSourceSimulator.NetworkSourceSimulator dataSource = new NetworkSourceSimulator.NetworkSourceSimulator(inputFilePath, 100, 200);

            dataSource.OnNewDataReady += DataSource_OnNewDataReady;
            // !!
            dataSource.OnIDUpdate += DataSource_OnIDUpdate;
            dataSource.OnContactInfoUpdate += DataSource_OnContactInfoUpdate;
            dataSource.OnPositionUpdate += DataSource_OnPositionUpdate;

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
                    case "report":
                        DoingReport();
                        break;
                    case "exit":
                        exitCommand = true;
                        break;
                    default:
                        break;
                }
            }

            dataSource.OnNewDataReady -= DataSource_OnNewDataReady;
            dataSource.OnIDUpdate -= DataSource_OnIDUpdate;
            dataSource.OnContactInfoUpdate -= DataSource_OnContactInfoUpdate;
            dataSource.OnPositionUpdate -= DataSource_OnPositionUpdate;
        }

        // Message handler
        private void DataSource_OnNewDataReady(object sender, NewDataReadyArgs args)
        {
            Message message = ((NetworkSourceSimulator.NetworkSourceSimulator)sender).GetMessageAt(args.MessageIndex);
            var str = System.Text.Encoding.Default.GetString(message.MessageBytes);

            MessageParser messageP = new MessageParser();
            IAviationObject resultObject = messageP.GetDataFromMessage(message.MessageBytes);

            lock (dataLock)
            {
                data.Add(resultObject);
            }
            logger.Log($"New object added with ID: {resultObject.Id}");
        }

        private void DataSource_OnIDUpdate(object sender, IDUpdateArgs args)
        {
            ulong objectID = args.ObjectID;
            ulong newObjectID = args.NewObjectID;

            IAviationObject aviationObjectToUpdate = null;

            lock (dataLock)
            {
                aviationObjectToUpdate = data.FirstOrDefault(obj => obj.Id == objectID);

                if (aviationObjectToUpdate != null)
                    aviationObjectToUpdate.Id = newObjectID;
            }
            if (aviationObjectToUpdate != null)
                Notify();
            logger.Log($"ID changed from {objectID} to {newObjectID}");
        }

        private void DataSource_OnContactInfoUpdate(object sender, ContactInfoUpdateArgs args)
        {
            ulong objectID = args.ObjectID;
            string phoneNumber = args.PhoneNumber;
            string emailAddress = args.EmailAddress;

            IContactInfo aviationObjectToUpdate = null;

            lock (dataLock)
            {
                aviationObjectToUpdate = data.FirstOrDefault(obj => obj.Id == objectID) as IContactInfo;

                if (aviationObjectToUpdate != null)
                {
                    aviationObjectToUpdate.Phone = phoneNumber;
                    aviationObjectToUpdate.Email = emailAddress;
                }
            }
            if (aviationObjectToUpdate != null)
                Notify();
            logger.Log($"Contact info changed for object with ID: {objectID}");
        }

        /// DODAJ O SAMOLOTAXCH
        private void DataSource_OnPositionUpdate(object sender, PositionUpdateArgs args)
        {
            ulong objectID = args.ObjectID;
            Single _Longitude = args.Longitude;
            Single _Latitude = args.Latitude; 
            Single _AMSL = args.AMSL;

            IPositionInfo aviationObjectToUpdate = null;

            lock (dataLock)
            {
                aviationObjectToUpdate = data.FirstOrDefault(obj => obj.Id == objectID) as IPositionInfo;

                if (aviationObjectToUpdate != null)
                {
                    aviationObjectToUpdate.Longitude = _Longitude;
                    aviationObjectToUpdate.Latitude = _Latitude;
                    aviationObjectToUpdate.AMSL = _AMSL;
                }
            }
            if (aviationObjectToUpdate != null)
            {
                Notify();
                // podac zmienna
                // UpdateData.UpdateFlights();
            }
            logger.Log($"Position updated for object with ID: {objectID}"); 
        }
    }
}