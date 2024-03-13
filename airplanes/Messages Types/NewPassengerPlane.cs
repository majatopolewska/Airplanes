using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static airplanes.Program;

namespace airplanes
{
    class NewPassengerPlane : IObject
    {
        public string messageType { get; set; } = "NPP";

        public UInt32 FollowingMessageLenght;
        public UInt64 Id;
        public string Serial;
        public string ISOCountryCode;
        public UInt16 ModelLenght;
        public string Model;
        public UInt16 FirstClassSize;
        public UInt16 BuisnessClassSize;
        public UInt16 EconomyClassSize;

        public NewPassengerPlane() : this(0, "", "", "", 0, 0, 0)
        { }

        public NewPassengerPlane(ulong id, string serial, string countryCode, string model, ushort firstClassSize, ushort businessClassSize, ushort economyClassSize)
        {
            Id = id;
            Serial = serial;
            ISOCountryCode = countryCode;
            Model = model;
            FirstClassSize = firstClassSize;
            BuisnessClassSize = businessClassSize;
            EconomyClassSize = economyClassSize;

            ModelLenght = (ushort)Model.Length;
            FollowingMessageLenght = (uint)(Serial.Length + ISOCountryCode.Length + Model.Length + 12); 
        }
    }
}
