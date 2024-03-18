using Avalonia;
using Mapsui.Projections;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static airplanes.Program;

namespace airplanes
{
    class Airport : IAviationObject
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

        public (double x, double y) CalculateDistance(Airport origin, Airport target)
        {
            (double origin_x, double origin_y) = SphericalMercator.FromLonLat(origin.Latitude, origin.Longitude);
            (double target_x, double target_y) = SphericalMercator.FromLonLat(target.Latitude, target.Longitude);

            (double distance_x, double distance_y) = (origin_x - target_x, origin_y - target_y);

            return (distance_x, distance_y);
        }

        public double CalculateAngle(Airport origin, Airport target)
        {
            (double origin_x, double origin_y) = SphericalMercator.FromLonLat(origin.Latitude, origin.Longitude);
            (double target_x, double target_y) = SphericalMercator.FromLonLat(target.Latitude, target.Longitude);

            (double distance_x, double distance_y) = (origin_x - target_x, origin_y - target_y);
            double angle_radians = Math.Atan2(distance_y, distance_x);

            if (angle_radians < 0)
            {
                angle_radians += 2 * Math.PI;
            }

            double angle_degrees = angle_radians * (180 / Math.PI);

            return angle_degrees;
        }

    }
}
