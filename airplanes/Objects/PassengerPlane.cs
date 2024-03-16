using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static airplanes.Program;

namespace airplanes
{
    class PassengerPlane : IAviationObject
    {
        public string messageType { get; set; } = "PP";

        public ulong Id;
        public string Serial;
        public string Country;
        public string Model;
        public ushort FirstClassSize;
        public ushort BusinessClassSize;
        public ushort EconomyClassSize;

        public PassengerPlane() : this(0, "", "", "", 0, 0, 0)
        {
        }
        public PassengerPlane(ulong id, string serial, string country, string model, ushort firstClassSize, ushort businessClassSize, ushort economyClassSize)
        {
            Id = id;
            Serial = serial;
            Country = country;
            Model = model;
            FirstClassSize = firstClassSize;
            BusinessClassSize = businessClassSize;
            EconomyClassSize = economyClassSize;
        }
    }
}
