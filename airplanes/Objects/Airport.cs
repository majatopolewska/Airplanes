using Avalonia;
using Mapsui;
using Mapsui.Projections;
using NetTopologySuite.Operation.Distance;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using static airplanes.Program;

namespace airplanes
{
    class Airport : IAviationObject, IReportable
    {
        public string messageType { get; set; } = "AI";

        public ulong Id;
        public string Name;
        public string Code;
        public Single Longitude;
        public Single Latitude;
        public Single AMSL;
        public string Country;

        public Airport() : this(0, "", "", 0.0f, 0.0f, 0.0f, "")
        {
        }

        public Airport(ulong id, string name, string code, float longitude, float latitude, float amsl, string country)
        {
            Id = id;
            Name = name;
            Code = code;
            Longitude = longitude;
            Latitude = latitude;
            AMSL = amsl;
            Country = country;
        }

        public static (double x, double y) CalculateDistance(Airport origin, Airport target)
        {
            (double origin_x, double origin_y) = (origin.Longitude, origin.Latitude);
            (double target_x, double target_y) = (target.Longitude, target.Latitude);

            (double distance_x, double distance_y) = (target_x - origin_x, target_y - origin_y);

            return (distance_x, distance_y);
        }

        public static double CalculateAngle(Airport origin, Airport target)
        {
            (double origin_x, double origin_y) = SphericalMercator.FromLonLat(origin.Longitude, origin.Latitude);
            (double target_x, double target_y) = SphericalMercator.FromLonLat(target.Longitude, target.Latitude);

            double angle = Math.Atan2(target_y - origin_y, origin_x - target_x) - Math.PI / 2.0;
            if (angle >= 0) angle += Math.PI;

            return angle;
        }

    }
}
