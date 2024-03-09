using static airplanes.Program;

namespace airplanes
{
    class Cargo
    {
        public ulong Id;
        public Single Weight;
        public string Code;
        public string Description;

        public Cargo() : this(0, 0.0f, "", "")
        {
        }
        public Cargo(ulong id, float weight, string code, string description)
        {
            Id = id;
            Weight = weight;
            Code = code;
            Description = description;
        }
    }
}
