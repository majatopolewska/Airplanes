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
        public IAviationObject Create(string[] values)
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

        public IAviationObject Parse(byte[] data)
        {
            UInt16 tempCrewCount = BitConverter.ToUInt16(data, 55);
            UInt64[] crew = new UInt64[tempCrewCount];
            for (int i = 0; i < tempCrewCount; i++)
            {
                crew[i] = BitConverter.ToUInt64(data, 57 + i * 8);
            }

            UInt16 tempPassCargCount = BitConverter.ToUInt16(data, 57 + tempCrewCount * 8);
            UInt64[] passCarg = new UInt64[tempPassCargCount];
            for (int i = 0; i < tempPassCargCount; i++)
            {
                passCarg[i] = BitConverter.ToUInt64(data, 59 + tempCrewCount * 8 + i * 8);
            }

            return new Flight
            {
                Id = BitConverter.ToUInt64(data, 7),
                OriginId = BitConverter.ToUInt64(data, 15),
                TargetId = BitConverter.ToUInt64(data, 23),
                TakeoffTime = BitConverter.ToString(data, 31, 8),
                LandingTime = BitConverter.ToString(data, 39, 8),
                PlaneId = BitConverter.ToUInt64(data, 47),
                CrewId = crew,
                LoadId = passCarg
            };
        }
    }
}
