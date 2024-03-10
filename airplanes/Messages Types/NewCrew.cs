using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using static airplanes.Program;

namespace airplanes
{
    class NewCrew : IObject
    {
        public string type { get; set; } = "NCR";

        public UInt32 FollowingMessageLenght;
        public UInt64 Id;
        public UInt16 NameLenght;
        public string Name;
        public UInt16 Age;
        public string PhoneNumber;
        public UInt16 EmailLenght;
        public string EmailAddress;
        public UInt16 Practice;
        public char Role;

        public NewCrew() : this(0, "", 0, "", "", 0 , ' ')
        { }

        public NewCrew(ulong id, string name, ushort age, string phoneNumber, string emailAddress, ushort practice, char role)
        {
            Id = id;
            Name = name;
            NameLenght = (ushort)Name.Length;
            Age = age;
            PhoneNumber = phoneNumber;
            EmailAddress = emailAddress;
            EmailLenght = (ushort)EmailAddress.Length;
            Practice = practice;
            Role = role;

            FollowingMessageLenght = (uint)(Name.Length + PhoneNumber.Length + EmailAddress.Length + 14);
        }
    }
}
