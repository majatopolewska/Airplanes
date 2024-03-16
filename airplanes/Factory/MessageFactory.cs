using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Numerics;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static airplanes.Program;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace airplanes
{
    // IObject zmienić nazwę
    // zostawić 1 factory i parse przerzucoc do folderu factory
    // usunac classy NEW
    public class MessageParser
    {
        public IAviationObject GetDataFromMessage(byte[] data)
        {
            string messageType = "";
            for (int i = 0; i < 3; i++)
            {
                messageType += Convert.ToChar(data[i]);
            }

            switch (messageType)
            {
                case "NAI": // NewAirport
                    return new AirportFactory().Parse(data);
                
                case "NCA": // NewCargo
                    return new CargoFactory().Parse(data);
                
                case "NCP": // NewCargoPlane
                    return new CargoPlaneFactory().Parse(data);
                
                case "NCR": // NewCrew
                    return new CrewFactory().Parse(data);
                
                case "NPA": // NewPassenger
                    return new PassengerFactory().Parse(data);
                
                case "NPP": // NewPassengerPlane
                    return new PassengerPlaneFactory().Parse(data);

                case "NFL": // NewFlight
                    return new FlightFactory().Parse(data);

                default:
                    throw new ArgumentException("Invalid type indicator");

            }
        }
    }
}
