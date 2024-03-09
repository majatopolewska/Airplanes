using static airplanes.Program;

namespace airplanes
{
    class Crew
    {
        public ulong Id;
        public string Name;
        public ulong Age;
        public string Phone;
        public string Email;
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
