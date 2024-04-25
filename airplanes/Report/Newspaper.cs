using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace airplanes
{
    class Newspaper : IMedia
    {
        public string Name;

        public Newspaper(string name)
        {
            Name = name;
        }
        public string Visit(Airport a)
        {
            return $"{Name} - A report from the {a.Name} airport, {a.Country}.";
        }
        public string Visit(CargoPlane cp)
        {
            return $"{Name} - An interview with crew of {cp.Serial}.";
        }
        public string Visit(PassengerPlane pp)
        {
            return $"{Name} - Breaking News! {pp.Model} aircraft loses EASA fails certification after inspection of {pp.Serial}.";
        }
    }
}
