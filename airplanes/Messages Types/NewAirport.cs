using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static airplanes.Program;

namespace airplanes
{
    class NewAirport : IObject
    {
        public string type { get; set; } = "NAI";

        public UInt32 FollowingMessageLenght;
        public UInt64 Id;
        public UInt16 NameLenght;
        public string Name;
        public string Code;
        public Single Longitude;
        public Single Latitude;
        public Single AMSL;
        public string ISOCountryCode;

        public NewAirport() : this(0, "", "", 0, 0, 0, "")
        { }

        public NewAirport(ulong id, string name, string code, float longitude, float latitude, float amsl, string countryCode)
        {
            Id = id;
            Name = name;
            Code = code;
            Longitude = longitude;
            Latitude = latitude;
            AMSL = amsl;
            ISOCountryCode = countryCode;

            NameLenght = (ushort)Name.Length;
            FollowingMessageLenght = (uint)(NameLenght + Code.Length + ISOCountryCode.Length + 22); 
        }
    }
}
