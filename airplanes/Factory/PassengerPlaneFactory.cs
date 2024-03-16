using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static airplanes.Program;

namespace airplanes
{
    public class PassengerPlaneFactory : IDataFactory
    {
        public IAviationObject Create(string[] values)
        {
            return new PassengerPlane
            {
                Id = ulong.Parse(values[1]),
                Serial = values[2],
                Country = values[3],
                Model = values[4],
                FirstClassSize = ushort.Parse(values[5]),
                BusinessClassSize = ushort.Parse(values[6]),
                EconomyClassSize = ushort.Parse(values[7])
            };
        }

        public IAviationObject Parse(byte[] data)
        {
            UInt16 ModelLenght = BitConverter.ToUInt16(data, 28);
            return new PassengerPlane
            {
                Id = BitConverter.ToUInt64(data, 7),
                Serial = Encoding.ASCII.GetString(data, 15, 10),
                Country = Encoding.ASCII.GetString(data, 25, 3),
                Model = Encoding.ASCII.GetString(data, 30, ModelLenght),
                FirstClassSize = BitConverter.ToUInt16(data, 30 + ModelLenght),
                BusinessClassSize = BitConverter.ToUInt16(data, 32 + ModelLenght),
                EconomyClassSize = BitConverter.ToUInt16(data, 34 + ModelLenght)
            };
        }
    }
}
