using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static airplanes.Program;

namespace airplanes
{
    class Flight : IAviationObject
    {
        public string messageType { get; set; } = "FL";

        public ulong Id;
        public ulong OriginId;
        public ulong TargetId;
        public string TakeoffTime;
        public string LandingTime;
        public Single Longitude;
        public Single Latitude;
        public Single AMSL;
        public ulong PlaneId;
        public ulong[] CrewId;
        public ulong[] LoadId;

        public Flight() : this(0, 0, 0, "", "", 0.0f, 0.0f, 0.0f, 0, new ulong[0], new ulong[0])
        {
        }

        public Flight(ulong id, ulong originId, ulong targetId, string takeoffTime, string landingTime, float longitude, float latitude, float amsl, ulong planeId, ulong[] crewId, ulong[] loadId)
        {
            Id = id;
            OriginId = originId;
            TargetId = targetId;
            TakeoffTime = takeoffTime;
            LandingTime = landingTime;
            Longitude = longitude;
            Latitude = latitude;
            AMSL = amsl;
            PlaneId = planeId;
            CrewId = crewId;
            LoadId = loadId;
        }
    }
}
