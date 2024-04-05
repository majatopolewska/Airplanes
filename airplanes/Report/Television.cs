using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace airplanes
{
    class Television : IMedia
    {
        public string Name;

        public Television(string name)
        {
            Name = name;
        }
        public string Visit(Airport a)
        {
            return $"<An image of {a.Name} airport>";
        }
        public string Visit(CargoPlane cp)
        {
            return $"<An image of {cp.Serial} cargo plane>";
        }
        public string Visit(PassengerPlane pp)
        {
            return $"<An image of {pp.Serial} passenger plane>";
        }
    }
}
