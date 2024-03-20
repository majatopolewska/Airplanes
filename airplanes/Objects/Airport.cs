using Avalonia;
using Mapsui;
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

        private const double Radius = 6378137;
        private const double D2R = Math.PI / 180;
        private const double HalfPi = Math.PI / 2;

        public static (double x, double y) AyFromLonLat(double lon, double lat)
        {
            var lonRadians = D2R * lon;
            var latRadians = D2R * lat;

            var x = Radius * lonRadians;

            var temp1 = Math.PI * 0.25 + latRadians * 0.5;
            var temp2 = Math.Tan(temp1);
            var y = Radius * Math.Log(temp2);

            return new(x, y);
        }

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

            (double distance_x, double distance_y) = (origin_x - target_x, origin_y - target_y);

            return (distance_x, distance_y);
        }

        public static double CalculateAngle(Airport origin, Airport target)
        {
            (double origin_x, double origin_y) = (origin.Longitude, origin.Latitude);
            (double target_x, double target_y) = (target.Longitude, target.Latitude);

            (double distance_x, double distance_y) = (target_x - origin_x, target_y - origin_y);
            double angle_radians = Math.Atan2(distance_y, distance_x);

            if (angle_radians < 0)
            {
                angle_radians += 2 * Math.PI;
            }

            return angle_radians;
        }

    }
}
