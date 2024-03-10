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

        public NewCargo() : this(0, 0, "", "")
        { }
        public NewCargo(ulong id, float weight, string code, string description)
        {
            Id = id;
            Weight = weight;
            Code = code.ToCharArray();
            Description = description.ToCharArray();

            DescriptionLenght = (ushort)Description.Length;
            FollowingMessageLenght = (uint)(DescriptionLenght + Code.Length + 18);
        }
    }
}
