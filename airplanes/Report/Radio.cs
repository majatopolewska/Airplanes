using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace airplanes
{
    class Radio
    {
        public string Name;

        public Radio(string name)
        {
            Name = name;
        }

        public string providingNews(IReportable repoertedObject)
        {
            if (repoertedObject is Airport a)
                return $"Reportinh for {Name}, Ladies and Gentlemen, we are at the {a.Name} airport.";
            else if (repoertedObject is CargoPlane cp)
                return $"Reporting {Name}, Ladies and Gentlemen, we are seeing the {cp.Serial} aircraft fly above us.";
            else if (repoertedObject is PassengerPlane pp)
                return $"Reporting {Name}, Ladies and Gentlemen, we are seeing the {pp.Serial} aircraft fly above us.";
            else
                return $"Report censured";
        }
    }
}
