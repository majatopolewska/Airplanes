using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static airplanes.Program;

namespace airplanes
{
    class Airport
    {
        public ulong Id;
        public string Name;
        public string Code;
        public Single Longitude;
        public Single Latitude;
        public Single AMSL;
        public string Country;

        public Airport() : this(0, "", "", 0.0f, 0.0f, 0.0f, "")
        {
        }

        public Airport(ulong id, string name, string code, float longitude, float latitude, float amsl, string country)
        {
            Id = id;
            Name = name;
            Code = code;
            Longitude = longitude;
            Latitude = latitude;
            AMSL = amsl;
            Country = country;
        }
    }
}
