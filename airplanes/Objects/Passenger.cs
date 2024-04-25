using static airplanes.Program;

namespace airplanes
{
    class Passenger : IAviationObject, IContactInfo
    {
        public string messageType { get; set; } = "P";

        public ulong Id { get; set; }
        public string Name;
        public ulong Age;
        public string Phone { get; set; }
        public string Email { get; set; }
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
