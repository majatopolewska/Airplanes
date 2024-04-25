using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace airplanes
{
    class Radio : IMedia
    {
        public string Name;

        public Radio(string name)
        {
            Name = name;
        }
        public string Visit(Airport a)
        {
            return $"Reporting for {Name}, Ladies and Gentlemen, we are at the {a.Name} airport.";
        }
        public string Visit(CargoPlane cp)
        {
            return $"Reporting {Name}, Ladies and Gentlemen, we are seeing the {cp.Serial} aircraft fly above us.";
        }
        public string Visit(PassengerPlane pp)
        {
            return $"Reporting {Name}, Ladies and Gentlemen, we are seeing the {pp.Serial} aircraft fly above us.";
        }
    }
}
