using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static airplanes.Program;

namespace airplanes
{
    public class AirportFactory : IDataFactory
    {
        public IAviationObject Create(string[] values)
        {
            return new Airport
            {
                Id = ulong.Parse(values[1]),
                Name = values[2],
                Code = values[3],
                Longitude = FormatData<float>(values[4]),
                Latitude = FormatData<float>(values[5]),
                AMSL = FormatData<float>(values[6]),
                Country = values[7]
            };
        }

        public IAviationObject Parse(byte[] data)
        {
            UInt16 NameLenght = BitConverter.ToUInt16(data, 15);
            return new Airport
            {
                Id = BitConverter.ToUInt64(data, 7),
                Name = Encoding.ASCII.GetString(data, 17, NameLenght),
                Code = Encoding.ASCII.GetString(data, 17 + NameLenght, 3),
                Longitude = BitConverter.ToSingle(data, 20 + NameLenght),
                Latitude = BitConverter.ToSingle(data, 24 + NameLenght),
                AMSL = BitConverter.ToSingle(data, 28 + NameLenght),
                Country = Encoding.ASCII.GetString(data, 32 + NameLenght, 3)
            };
        }
    }
}
