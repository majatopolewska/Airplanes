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
                case "NAI": // NewAirport
                    return ParseNewAirport(data);
                case "NCA": // NewCargo
                    return ParseNewCargo(data);
                case "NCP": // NewCargoPlane
                    return ParseNewCargoPlane(data);
                case "NCR": // NewCrew
                    return ParseNewCrew(data);
                case "NPA": // NewPassenger
                    return ParseNewPassenger(data);
                case "NPP": // NewPassengerPlane
                    return ParseNewPassengerPlane(data);
                case "NFL": // NewFlight
                    return ParseNewFlight(data); 
                default:
                    throw new ArgumentException("Invalid type indicator");

            }
        }

        private NewAirport ParseNewAirport(byte[] data)
        {
            UInt16 NameLenght = BitConverter.ToUInt16(data, 15);
            return new NewAirport
            {
                Id = BitConverter.ToUInt64(data, 7),
                Name = Encoding.ASCII.GetString(data, 17, NameLenght),
                Code = Encoding.ASCII.GetString(data, 17+NameLenght, 3),
                Longitude = BitConverter.ToSingle(data, 20+NameLenght),
                Latitude = BitConverter.ToSingle(data, 24 + NameLenght),
                AMSL = BitConverter.ToSingle(data, 28 + NameLenght),
                ISOCountryCode = Encoding.ASCII.GetString(data, 32+NameLenght, 3)
            };
        }
        private NewCargo ParseNewCargo(byte[] data)
        {
            UInt16 DescriptionLenght = BitConverter.ToUInt16(data, 25);
            return new NewCargo 
            {
                Id = BitConverter.ToUInt64(data, 7),
                Weight = BitConverter.ToSingle(data, 15),
                Code = Encoding.ASCII.GetString(data, 19, 6),
                Description = Encoding.ASCII.GetString(data, 27, DescriptionLenght)
            };
        }

        private NewCargoPlane ParseNewCargoPlane(byte[] data)
        {
            UInt16 ModelLenght = BitConverter.ToUInt16(data, 28);
            return new NewCargoPlane 
            {
                Id = BitConverter.ToUInt64(data, 7),
                Serial = Encoding.ASCII.GetString(data, 15, 10),
                ISOCountryCode = Encoding.ASCII.GetString(data, 25, 3),
                Model = Encoding.ASCII.GetString(data, 30, ModelLenght),
                MaxLoad = BitConverter.ToSingle(data, 30+ModelLenght)
            };
        }
        private NewCrew ParseNewCrew(byte[] data)
        {
            UInt16 NameLenght = BitConverter.ToUInt16(data, 15);
            UInt16 EmailLenght = BitConverter.ToUInt16(data, 31+NameLenght);

            
            UInt64  Id = BitConverter.ToUInt64(data, 7);
            string Name = Encoding.ASCII.GetString(data, 17, NameLenght);
            UInt16 Age = BitConverter.ToUInt16(data, 17 + NameLenght);
            string PhoneNumber = Encoding.ASCII.GetString(data, 19 + NameLenght, 12);
            string EmailAddress = Encoding.ASCII.GetString(data, 33 + NameLenght, EmailLenght);
            UInt16 Practice = BitConverter.ToUInt16(data, 33 + NameLenght + EmailLenght);
            char Role = (char)data[ 35 + NameLenght + EmailLenght];
            

            return new NewCrew
            {
                Id = BitConverter.ToUInt64(data, 7),
                Name = Encoding.ASCII.GetString(data, 17, NameLenght),
                Age = BitConverter.ToUInt16(data, 17 + NameLenght),
                PhoneNumber = Encoding.ASCII.GetString(data, 19 + NameLenght, 12),
                EmailAddress = Encoding.ASCII.GetString(data, 33 + NameLenght, EmailLenght),
                Practice = BitConverter.ToUInt16(data, 33 + NameLenght + EmailLenght),
                Role = (char)data[35 + NameLenght + EmailLenght]
            };
        }
        
        private NewFlight ParseNewFlight(byte[] data)
        {
            UInt16 tempCrewCount = BitConverter.ToUInt16(data, 55);
            UInt64[] crew = new UInt64[tempCrewCount];
            for (int i = 0; i < tempCrewCount; i++)
            {
                crew[i] = BitConverter.ToUInt64(data, 57 + i * 8);
            }

            UInt16 tempPassCargCount = BitConverter.ToUInt16(data, 57 + tempCrewCount * 8);
            UInt64[] passCarg = new UInt64[tempPassCargCount];
            for (int i = 0; i < tempPassCargCount; i++)
            {
                passCarg[i] = BitConverter.ToUInt64(data, 59 + tempCrewCount * 8 + i * 8);
            }

            return new NewFlight
            {
                Id = BitConverter.ToUInt64(data, 7),
                OriginId = BitConverter.ToUInt64(data, 15),
                TargetId = BitConverter.ToUInt64(data, 23),
                TakeOffTime = BitConverter.ToInt64(data, 31),
                LandingTime = BitConverter.ToInt64(data, 39),
                PlaneId = BitConverter.ToUInt64(data, 47),
                CrewCount = tempCrewCount,
                Crew = crew,
                PassCargCount = tempPassCargCount,
                PassCarg = passCarg
            };
        }

        private NewPassenger ParseNewPassenger(byte[] data)
        {
            UInt16 NameLenght = BitConverter.ToUInt16(data, 15);
            UInt16 EmailLenght = BitConverter.ToUInt16(data, 31 + NameLenght);
            return new NewPassenger
            {
                Id = BitConverter.ToUInt64(data, 7),
                Name = Encoding.ASCII.GetString(data, 17, NameLenght),
                Age = BitConverter.ToUInt16(data, 17 + NameLenght),
                PhoneNumber = Encoding.ASCII.GetString(data, 19 + NameLenght, 12),
                EmailAddress = Encoding.ASCII.GetString(data, 33 + NameLenght, EmailLenght),
                Class = (char)data[33 + NameLenght + EmailLenght],
                Miles = BitConverter.ToUInt64(data, 34 + NameLenght + EmailLenght)
            };
        }

        private NewPassengerPlane ParseNewPassengerPlane(byte[] data)
        {
            UInt16 ModelLenght = BitConverter.ToUInt16(data, 28);
            return new NewPassengerPlane
            {
                Id = BitConverter.ToUInt64(data, 7),
                Serial = Encoding.ASCII.GetString(data, 15, 10),
                ISOCountryCode = Encoding.ASCII.GetString(data, 25, 3),
                Model = Encoding.ASCII.GetString(data, 30, ModelLenght),
                FirstClassSize = BitConverter.ToUInt16(data, 30 + ModelLenght),
                BuisnessClassSize = BitConverter.ToUInt16(data, 32 +  ModelLenght),
                EconomyClassSize = BitConverter.ToUInt16(data, 34 +ModelLenght)
            };
        }

    }
}
