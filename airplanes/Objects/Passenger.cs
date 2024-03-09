using static airplanes.Program;

namespace airplanes
{
    class Passenger
    {
        public ulong Id;
        public string Name;
        public ulong Age;
        public string Phone;
        public string Email;
        public string Class;
        public ulong Miles;

        public Passenger() : this(0, "", 0, "", "", "", 0)
        {
        }
        public Passenger(ulong id, string name, ulong age, string phone, string email, string @class, ulong miles)
        {
            Id = id;
            Name = name;
            Age = age;
            Phone = phone;
            Email = email;
            Class = @class;
            Miles = miles;
        }
    }
}
