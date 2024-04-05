using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static airplanes.Program;

namespace airplanes
{
    public class CargoPlane : IAviationObject, IReportable
    {
        public string messageType { get; set; } = "CP";

        public ulong Id;
        public string Serial;
        public string Country;
        public string Model;
        public Single MaxLoad;

        public CargoPlane() : this(0, "", "", "", 0.0f)
        {
        }

        public CargoPlane(ulong id, string serial, string country, string model, float maxLoad)
        {
            Id = id;
            Serial = serial;
            Country = country;
            Model = model;
            MaxLoad = maxLoad;
        }

        public string ReportNews(IMedia visitor)
        {
            return visitor.Visit(this);
        }
    }
}
