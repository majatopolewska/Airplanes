using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static airplanes.Program;

namespace airplanes
{
    public class MessageFactory : IMessageFactory
    {
        public IObject Create(byte[] data)
        {
            string messageType = "";
            for (int i = 0; i < 3; i++)
            {
                messageType += Convert.ToChar(data[i]);
            }

            switch (messageType)
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

        private NewCargoPlane ParseNewCargoPlane()
        {
            return new NewCargoPlane(

            );
        }
        private NewCrew ParseNewCrew(byte[] data)
        {
            UInt16 NameLenght = BitConverter.ToUInt16(data, 15);
            UInt16 EmailLenght = BitConverter.ToUInt16(data, 31+NameLenght);
            return new NewCrew
            {
                Id = BitConverter.ToUInt64(data, 7),
                Name = BitConverter.ToString(data, 17, NameLenght),
                Age = BitConverter.ToUInt16(data, 17 + NameLenght),
                PhoneNumber = BitConverter.ToString(data, 19 + NameLenght, 12),
                EmailAddress = BitConverter.ToString(data, 33 + NameLenght, EmailLenght),
                Practice = BitConverter.ToUInt16(data, 33 + NameLenght + EmailLenght),
                Role = BitConverter.ToChar(data, 35 + NameLenght + EmailLenght)
            };

        }
    }
}
