using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static airplanes.Program;

namespace airplanes
{
    public class PassengerFactory : IDataFactory
    {
        public IAviationObject Create(string[] values)
        {
            return new Passenger
            {
                Id = ulong.Parse(values[1]),
                Name = values[2],
                Age = ulong.Parse(values[3]),
                Phone = values[4],
                Email = values[5],
                Class = values[6],
                Miles = ulong.Parse(values[7])
            };
        }

        public IAviationObject Parse(byte[] data)
        {
            UInt16 NameLenght = BitConverter.ToUInt16(data, 15);
            UInt16 EmailLenght = BitConverter.ToUInt16(data, 31 + NameLenght);
            return new Passenger
            {
                Id = BitConverter.ToUInt64(data, 7),
                Name = Encoding.ASCII.GetString(data, 17, NameLenght),
                Age = BitConverter.ToUInt16(data, 17 + NameLenght),
                Phone = Encoding.ASCII.GetString(data, 19 + NameLenght, 12),
                Email = Encoding.ASCII.GetString(data, 33 + NameLenght, EmailLenght),
                Class = Encoding.ASCII.GetString(data, 33 + NameLenght + EmailLenght, 1),
                Miles = BitConverter.ToUInt64(data, 34 + NameLenght + EmailLenght)
            };
        }
    }
}
