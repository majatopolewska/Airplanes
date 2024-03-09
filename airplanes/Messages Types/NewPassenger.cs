using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static airplanes.Program;

namespace airplanes
{
    class NewPassenger : IObject
    {
        public string type { get; set; } = "NPA";

        public UInt32 FollowingMessageLenght;
        public UInt64 Id;
        public UInt16 NameLenght;
        public char[] Name;
        public UInt16 Age;
        public char[] PhoneNumber;
        public UInt16 EmailLenght;
        public char[] EmailAdress;
        public char Class;
        public UInt64 Miles;
    }
}
