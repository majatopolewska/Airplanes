using Svg.FilterEffects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace airplanes
{
    public class Report
    {
        private static List<IReportable> reportedObjects;

        public Report()
        {
            reportedObjects = new List<IReportable>();
        }

        private static List<object> newsProvidersGenerator()
        {
            var newsProviders = new List<object>();
            Radio radioQ = new Radio("Quatifier radio");
            Radio radioS = new Radio("Shmem radio");
            Television tvA = new Television("Abelian Television");
            Television tvCT = new Television("Chanel TV-Tenson");
            Newspaper nCJ = new Newspaper("Categories Journal");
            Newspaper nPG = new Newspaper("Polytechincal Gazette");

            newsProviders.Add(radioQ);
            newsProviders.Add(radioS);
            newsProviders.Add(tvA);
            newsProviders.Add(tvCT);
            newsProviders.Add(nCJ);
            newsProviders.Add(nPG);

            return newsProviders;
        }
            
        public static void objectsToReport()
        {
            string inputFile = "data.ftr";
            string currentDirectory = Directory.GetCurrentDirectory();
            string inputFilePath = Path.Combine(currentDirectory, inputFile);

            List<IAviationObject> data = ReadFile.ReadDataFromFile(inputFilePath);
            foreach (IAviationObject obj in data) 
            {
                if(obj is IReportable iR)
                {
                    reportedObjects.Add(iR);
                }
            }
        }

        public static void DoingReport()
        {
            objectsToReport();
            List<object> newsProviders = newsProvidersGenerator();
            NewsGenerator newsGenerator = new NewsGenerator(newsProviders, reportedObjects);
            string? reportNews;
            while( (reportNews = newsGenerator.GenerateNextNews()) != null)
            {
                Console.WriteLine(reportNews);
            }
        }
    }
}
