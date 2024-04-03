using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace airplanes
{
    class Newspaper
    {
        public string Name;

        public Newspaper(string name)
        {
            Name = name;
        }

        public string providingNews(IReportable repoertedObject)
        {
            if (repoertedObject is Airport a)
                return $"{Name} - A report from the {a.Name} airport, {a.Country}.";
            else if (repoertedObject is CargoPlane cp)
                return $"{Name} - An interview with crew of {cp.Serial}.";
            else if (repoertedObject is PassengerPlane pp)
                return $"{Name} - Breaking News! {pp.Model} aircraft loses EASA fails certification after inspection of {pp.Serial}.";
            else
                return $"Report censured";
        }
    }
}
