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
        public object Create(string[] values)
        {
            return new Cargo
            {
                Id = ulong.Parse(values[1]),
                Weight = FormatData<Single>(values[2]),
                Code = values[3],
                Description = values[4]
            };
        }
    }
}
