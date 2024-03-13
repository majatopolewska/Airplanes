using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static airplanes.Program;

namespace airplanes
{
    class NewFlight : IObject
    {
        public string messageType { get; set; } = "NFL";

        public UInt32 FollowingMessageLenght;
        public UInt64 Id;
        public UInt64 OriginId;
        public UInt64 TargetId;
        public Int64 TakeOffTime; // number of ms since EPOCH
        public Int64 LandingTime; // number of ms since EPOCH
        public UInt64 PlaneId;
        public UInt16 CrewCount;
        public UInt64[] Crew;
        public UInt16 PassCargCount; // passenger/cargo count - we don't know what type of plane
        public UInt64[] PassCarg;

        public NewFlight() : this(0, 0, 0, 0, 0, 0, 0, new ulong[0], 0, new ulong[0])
        { }

        public NewFlight(ulong id, ulong originId, ulong targetId, long takeOffTime, long landingTime, ulong planeId, ushort crewCount, ulong[] crew, ushort passCargCount, ulong[] passCarg)
        {
            Id = id;
            OriginId = originId;
            TargetId = targetId;
            TakeOffTime = takeOffTime;
            LandingTime = landingTime;
            PlaneId = planeId;
            CrewCount = crewCount;
            Crew = crew;
            PassCargCount = passCargCount;
            PassCarg = passCarg;

            FollowingMessageLenght = (uint)(crew.Length * sizeof(ulong) + passCarg.Length * sizeof(ulong) + 40); // Assuming 40 is the total size of other fields
        }
    }
}
