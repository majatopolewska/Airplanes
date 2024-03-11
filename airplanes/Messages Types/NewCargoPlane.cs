using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static airplanes.Program;

namespace airplanes
{
    class NewCargoPlane : IObject
    {
        public string type { get; set; } = "NCP";

        public UInt32 FollowingMessageLenght;
        public UInt64 Id;
        public string Serial;
        public string ISOCountryCode;
        public UInt16 ModelLenght;
        public string Model;
        public Single MaxLoad;

        public NewCargoPlane() : this(0, "", "", "", 0)
        { }
        public NewCargoPlane(ulong id, string serial, string countryCode, string model, float maxLoad)
        {
            Id = id;
            Serial = serial;
            ISOCountryCode = countryCode;
            Model = model;
            MaxLoad = maxLoad;

            ModelLenght = (ushort)Model.Length;
            FollowingMessageLenght = (uint)(Serial.Length + ISOCountryCode.Length + Model.Length + 20);
        }
    }
}
