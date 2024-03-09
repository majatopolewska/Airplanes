using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static airplanes.Program;

namespace airplanes
{
    class CargoPlane
    {
        public ulong Id;
        public string Serial;
        public string Country;
        public string Model;
        public Single MaxLoad;

        public CargoPlane() : this(0, "", "", "", 0.0f)
        {
        }

        public CargoPlane(ulong id, string serial, string country, string model, float maxLoad)
        {
            Id = id;
            Serial = serial;
            Country = country;
            Model = model;
            MaxLoad = maxLoad;
        }
    }
}
