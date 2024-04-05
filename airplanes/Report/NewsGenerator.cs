using Avalonia.Controls.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace airplanes
{
    public class NewsGenerator
    {
        private readonly IEnumerable<IMedia> newsProviders;
        private readonly IEnumerable<IReportable> reportedObjects;

        public NewsGenerator(IEnumerable<IMedia> providers, IEnumerable<IReportable> reported)
        {
            newsProviders = providers;
            reportedObjects = reported;
        }

        public IEnumerable<string> GenerateNextNews()
        {
            foreach (var newsProvider in newsProviders)
            {
                foreach (var reportedObject in reportedObjects)
                {
                    if (reportedObject is Airport airport)
                        yield return newsProvider.Visit(airport);
                    else if (reportedObject is CargoPlane cargoPlane)
                        yield return newsProvider.Visit(cargoPlane);
                    else if (reportedObject is PassengerPlane passengerPlane)
                        yield return newsProvider.Visit(passengerPlane);
                    else
                        yield return "Report censured";
                }
            }
            yield return null;
        }
    }
}
