using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static airplanes.Program;

namespace airplanes
{
    public class AirplaneFactory : INewDataFactory
    {
        public IObject Create(string data)
        {
            switch (data)
            {
                case "NIA": // NewAirport
                    return ParseNewAirport();
                /*
                case "NCA": // NewCargo
                    return ParseNewCargo();
                case "NCP": // NewCargoPlane
                    return ParseNewCargoPlane();
                case "NCR": // NewCrew
                    return ParseNewCrew();
                case "NPA": // NewPassenger
                    return ParseNewPassenger();
                case "NPP": // NewPassengerPlane
                    return ParseNewPassengerPlane();
                case "NFL": // NewFlight
                    return ParseNewFlight();
                */
                default:
                    throw new ArgumentException("Invalid type indicator");
            }
        }

        private NewAirport ParseNewAirport()
        {
            return new NewAirport(
                   
            );
        }
        private NewCargo ParseNewCargo()
        {
            return new NewCargo();
        }
    }
}
