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
        public object Create(string[] values)
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
    }
}
