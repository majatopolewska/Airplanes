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
        public IObject Create(string[] values)
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
    }
}
