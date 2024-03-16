using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static airplanes.Program;

namespace airplanes
{
    public class CargoPlaneFactory : IDataFactory
    {
        public IAviationObject Create(string[] values)
        {
            return new CargoPlane
            {
                Id = ulong.Parse(values[1]),
                Serial = values[2],
                Country = values[3],
                Model = values[4],
                MaxLoad = FormatData<Single>(values[5]),
            };
        }
        public IAviationObject Parse(byte[] data)
        {
            UInt16 ModelLenght = BitConverter.ToUInt16(data, 28);
            return new CargoPlane
            {
                Id = BitConverter.ToUInt64(data, 7),
                Serial = Encoding.ASCII.GetString(data, 15, 10),
                Country = Encoding.ASCII.GetString(data, 25, 3),
                Model = Encoding.ASCII.GetString(data, 30, ModelLenght),
                MaxLoad = BitConverter.ToSingle(data, 30 + ModelLenght)
            };
        }
    }
}
