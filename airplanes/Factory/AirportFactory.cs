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
        public object Create(string[] values)
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
    }
}
