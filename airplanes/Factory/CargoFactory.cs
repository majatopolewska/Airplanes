using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static airplanes.Program;

namespace airplanes
{
    public class CargoFactory : IDataFactory
    {
        public IAviationObject Create(string[] values)
        {
            return new Cargo
            {
                Id = ulong.Parse(values[1]),
                Weight = FormatData<Single>(values[2]),
                Code = values[3],
                Description = values[4]
            };
        }

        public IAviationObject Parse(byte[] data)
        {
            UInt16 DescriptionLenght = BitConverter.ToUInt16(data, 25);
            return new Cargo
            {
                Id = BitConverter.ToUInt64(data, 7),
                Weight = BitConverter.ToSingle(data, 15),
                Code = Encoding.ASCII.GetString(data, 19, 6),
                Description = Encoding.ASCII.GetString(data, 27, DescriptionLenght)
            };
        }
    }
}
