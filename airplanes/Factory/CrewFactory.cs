using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static airplanes.Program;

namespace airplanes
{
    public class CrewFactory : IDataFactory
    {
        public IAviationObject Create(string[] values)
        {
            return new Crew
            {
                Id = ulong.Parse(values[1]),
                Name = values[2],
                Age = ulong.Parse(values[3]),
                Phone = values[4],
                Email = values[5],
                Practice = ushort.Parse(values[6]),
                Role = values[7]
            };
        }

        public IAviationObject Parse(byte[] data)
        {
            UInt16 NameLenght = BitConverter.ToUInt16(data, 15);
            UInt16 EmailLenght = BitConverter.ToUInt16(data, 31 + NameLenght);


            UInt64 Id = BitConverter.ToUInt64(data, 7);
            string Name = Encoding.ASCII.GetString(data, 17, NameLenght);
            UInt16 Age = BitConverter.ToUInt16(data, 17 + NameLenght);
            string PhoneNumber = Encoding.ASCII.GetString(data, 19 + NameLenght, 12);
            string EmailAddress = Encoding.ASCII.GetString(data, 33 + NameLenght, EmailLenght);
            UInt16 Practice = BitConverter.ToUInt16(data, 33 + NameLenght + EmailLenght);
            char Role = (char)data[35 + NameLenght + EmailLenght];


            return new Crew
            {
                Id = BitConverter.ToUInt64(data, 7),
                Name = Encoding.ASCII.GetString(data, 17, NameLenght),
                Age = BitConverter.ToUInt16(data, 17 + NameLenght),
                Phone = Encoding.ASCII.GetString(data, 19 + NameLenght, 12),
                Email = Encoding.ASCII.GetString(data, 33 + NameLenght, EmailLenght),
                Practice = BitConverter.ToUInt16(data, 33 + NameLenght + EmailLenght),
                Role = Encoding.ASCII.GetString(data, 35 + NameLenght + EmailLenght, 1),
            };
        }
    }
}
