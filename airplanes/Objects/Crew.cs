using static airplanes.Program;

namespace airplanes
{
    class Crew : IAviationObject, IContactInfo
    {
        public string messageType { get; set; } = "C";

        public ulong Id { get; set; }
        public string Name;
        public ulong Age;
        public string Phone { get; set; }
        public string Email { get; set; }
        public ushort Practice;
        public string Role;

        public Crew() : this(0, "", 0, "", "", 0, "")
        {
        }
        public Crew(ulong id, string name, ulong age, string phone, string email, ushort practice, string role)
        {
            Id = id;
            Name = name;
            Age = age;
            Phone = phone;
            Email = email;
            Practice = practice;
            Role = role;
        }
    }
}
