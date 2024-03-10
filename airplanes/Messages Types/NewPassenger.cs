using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using static airplanes.Program;

namespace airplanes
{
    class NewPassenger : IObject
    {
        public string type { get; set; } = "NPA";

        public UInt32 FollowingMessageLenght;
        public UInt64 Id;
        public UInt16 NameLenght;
        public char[] Name;
        public UInt16 Age;
        public char[] PhoneNumber;
        public UInt16 EmailLenght;
        public char[] EmailAdress;
        public char Class;
        public UInt64 Miles;

        public NewPassenger() : this(0, "", 0, "", "", ' ', 0)
        { }

        public NewPassenger(ulong id, string name, ushort age, string phoneNumber, string emailAddress, char passengerClass, ulong miles)
        {
            Id = id;
            Name = name.ToCharArray();
            NameLenght = (ushort)Name.Length;
            Age = age;
            PhoneNumber = phoneNumber.ToCharArray();
            EmailAdress = emailAddress.ToCharArray();
            EmailLenght = (ushort)EmailAdress.Length;
            Class = passengerClass;
            Miles = miles;

            FollowingMessageLenght = (uint)(Name.Length + PhoneNumber.Length + EmailAdress.Length + 15);
        }
    }
}
