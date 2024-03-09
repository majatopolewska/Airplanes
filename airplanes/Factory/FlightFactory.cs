using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static airplanes.Program;

namespace airplanes
{
    public class FlightFactory : IDataFactory
    {
        public object Create(string[] values)
        {
            var crewIdsString = values[10].Trim('[', ']');
            var crewIdsArray = crewIdsString.Split(';').Select(ulong.Parse).ToArray();

            var loadIdsString = values[11].Trim('[', ']');
            var loadIdsArray = loadIdsString.Split(';').Select(ulong.Parse).ToArray();

            return new Flight
            {
                Id = ulong.Parse(values[1]),
                OriginId = ulong.Parse(values[2]),
                TargetId = ulong.Parse(values[3]),
                TakeoffTime = values[4],
                LandingTime = values[5],
                Longitude = FormatData<float>(values[6]),
                Latitude = FormatData<float>(values[7]),
                AMSL = FormatData<float>(values[8]),
                PlaneId = ulong.Parse(values[9]),
                CrewId = crewIdsArray,
                LoadId = loadIdsArray
            };
        }
    }
}
