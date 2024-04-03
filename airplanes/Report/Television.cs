using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace airplanes
{
    class Television
    {
        public string Name;

        public Television(string name)
        {
            Name = name;
        }

        public string providingNews(IReportable repoertedObject)
        {
            if (repoertedObject is Airport a)
                return $"<An image of {a.Name} airport>";
            else if (repoertedObject is CargoPlane cp)
                return $"<An image of {cp.Serial} cargo plane>";
            else if (repoertedObject is PassengerPlane pp)
                return $"<An image of {pp.Serial} passenger plane>";
            else
                return $"Report censured";
        }
    }
}
