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
        public string type { get; set; } = "NPP";

        public UInt32 FollowingMessageLenght;
        public UInt64 Id;
        public char[] Serial;
        public char[] ISOCountryCode;
        public UInt16 ModelLenght;
        public char[] Model;
        public UInt16 FirstClassSize;
        public UInt16 BuisnessClassSize;
        public UInt16 EconomyClassSize;
    }
}
