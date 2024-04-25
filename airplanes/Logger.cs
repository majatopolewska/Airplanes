using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace airplanes
{
    public class Logger
    {
        // private readonly string DirectoryPathLog = "C:\\Users\\majat\\Dokumenty\\GitHub\\Object-Oriented-Design\\airplanes\\Data";

        private readonly string DirectoryPathLog = Directory.GetCurrentDirectory();
        private static readonly object loggerLock = new object();
        public Logger()
        {
            if (!Directory.Exists(DirectoryPathLog))
            {
                Directory.CreateDirectory(DirectoryPathLog);
            }
        }

        public void Log(string message)
        {
            string logFileName = $"log_{DateTime.Now:yyyyMMdd}.txt";
            string logFilePath = Path.Combine(DirectoryPathLog, logFileName);

            string formattedMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}";
            Console.WriteLine("XDDDD");
            lock (loggerLock)
            {
                using (StreamWriter writer = File.AppendText(logFilePath))
                {
                    writer.WriteLine(formattedMessage);
                }
            }
            
        }

    }
}
