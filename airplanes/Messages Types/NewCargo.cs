using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static airplanes.Program;

namespace airplanes
{
    class NewCargo : IObject
    {
        public string type { get; set; } = "NCA";

        public UInt32 FollowingMessageLenght;
        public UInt64 Id;
        public Single Weight;
        public char[] Code;
        public UInt16 DescriptionLenght;
        public char[] Description;
    }
}
