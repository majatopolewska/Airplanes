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
        public IObject Create(string[] values)
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
    }
}
