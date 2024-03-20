using System.Collections.Generic;
using System.Threading;
using NetworkSourceSimulator; // Assuming this namespace contains required classes
using System.IO;

namespace airplanes
{
    /*
    using Mapsui.Projections;
    using FlightTrackerGUI;

    namespace OOD
    {
        internal class GUI
        {
            readonly struct FlightCalcData(ulong iD, TimeSpan takeoffTime, TimeSpan landingTime, double speedX, double speedY, double originX, double originY)
            {
                public ulong ID { get; } = iD;
                public TimeSpan TakeoffTime { get; } = takeoffTime;
                public TimeSpan LandingTime { get; } = landingTime;
                public double SpeedX { get; } = speedX;
                public double SpeedY { get; } = speedY;
                public double OriginX { get; } = originX;
                public double OriginY { get; } = originY;
            }
            private static readonly List<FlightCalcData> flightsCalcData = [];
            private static System.Timers.Timer aTimer = new();
            private static List<FlightGUI> flightsData = [];
            public static void Run()
            {
                Task.Run(Runner.Run);
                SetTimer();
                Console.ReadLine();
                aTimer.Stop();
                aTimer.Dispose();
            }
            private static void SetTimer()
            {
                aTimer = new System.Timers.Timer(1000);
                aTimer.Elapsed += UpdateGUI;
                aTimer.AutoReset = true;
                aTimer.Enabled = true;
            }
            private static void UpdateGUI(object? source, System.Timers.ElapsedEventArgs e) => UpdateGUIData();
            private static void UpdateGUIData()
            {
                var newFlightsData = new List<FlightGUI>();
                foreach (var flight in flightsData)
                {
                    newFlightsData.Add(new FlightGUI
                    {
                        ID = flight.ID,
                        WorldPosition = CurrentWorldPosition(flightsCalcData.Find(x => x.ID == flight.ID)),
                        MapCoordRotation = flight.MapCoordRotation
                    });

                }
                flightsData = newFlightsData;
                var flightsToDraw = new List<FlightGUI>();
                foreach (var flight in flightsData)
                {
                    if (flight.WorldPosition.Latitude != 0 && flight.WorldPosition.Longitude != 0) flightsToDraw.Add(flight);
                }
                Runner.UpdateGUI(new FlightsGUIData(flightsToDraw));
            }
            public static void AddFlights(List<Flight> flights, List<Airport> airports)
            {
                var newFlightsData = new List<FlightGUI>();
                foreach (FlightGUI flight in flightsData) newFlightsData.Add(flight);
                foreach (Flight flight in flights)
                {
                    if (flightsData.Find(x => x.ID == flight.ID) != null) throw new Exception("Plane with this ID already exists in GUI");
                    var originAirport = airports.Find(x => x.ID == flight.OriginID) ?? throw new Exception($"No airport. FID: {flight.ID}");
                    var targetAirport = airports.Find(x => x.ID == flight.TargetID) ?? throw new Exception($"No airport. FID: {flight.ID}");
                    var originXY = SphericalMercator.FromLonLat(originAirport.Longitude, originAirport.Latitude);
                    var targetXY = SphericalMercator.FromLonLat(targetAirport.Longitude, targetAirport.Latitude);
                    double mapCoordRotation = Math.Atan2(targetXY.y - originXY.y, originXY.x - targetXY.x) - Math.PI / 2.0;
                    if (mapCoordRotation >= 0) mapCoordRotation += Math.PI;
                    var tTime = TimeSpan.ParseExact(flight.TakeoffTime, "h\\:mm", null);
                    var lTime = TimeSpan.ParseExact(flight.LandingTime, "h\\:mm", null);
                    var flightTime = lTime < tTime ? 24 * 3600 - tTime.TotalSeconds + lTime.TotalSeconds : (lTime - tTime).TotalSeconds;
                    var speedX = (targetXY.x - originXY.x) / flightTime;
                    var speedY = (targetXY.y - originXY.y) / flightTime;
                    FlightCalcData flightCalcData = new(flight.ID, tTime, lTime, speedX, speedY, originXY.x, originXY.y);
                    flightsCalcData.Add(flightCalcData);
                    newFlightsData.Add(new FlightGUI
                    {
                        ID = flight.ID,
                        WorldPosition = CurrentWorldPosition(flightCalcData),
                        MapCoordRotation = mapCoordRotation
                    });
                }
                flightsData = newFlightsData;
            }
            private static double CurrentFlightTime(TimeSpan takeOff, TimeSpan landing)
            {
                TimeSpan cT = DateTime.Now.TimeOfDay;
                if (landing < takeOff && cT <= landing) return (cT.TotalSeconds + 24 * 3600) - takeOff.TotalSeconds;
                if ((landing < takeOff && cT >= takeOff) || (cT >= takeOff && cT <= landing)) return (cT - takeOff).TotalSeconds;
                return -1;
            }
            private static WorldPosition CurrentWorldPosition(FlightCalcData fcd)
            {
                double currentFlightTime = CurrentFlightTime(fcd.TakeoffTime, fcd.LandingTime);
                if (currentFlightTime >= 0)
                {
                    var currentX = fcd.OriginX + fcd.SpeedX * currentFlightTime;
                    var currentY = fcd.OriginY + fcd.SpeedY * currentFlightTime;
                    var (lon, lat) = SphericalMercator.ToLonLat(currentX, currentY);
                    return new WorldPosition(lat, lon);
                }
                return new WorldPosition(0, 0);
            }
        }
    }
    */
}
