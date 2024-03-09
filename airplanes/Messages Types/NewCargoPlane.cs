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
        public char[] Serial;
        public char[] ISOCountryCode;
        public UInt16 ModelLenght;
        public char[] Model;
        public Single MaxLoad;
    }
}
