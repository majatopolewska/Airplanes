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
        public IObject Create(string[] values)
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
    }
}
