using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace airplanes
{
    public interface IObject
    {
        string type { get; set; }
    }
    public interface IDataFactory
    {
        public IObject Create(string[] values);
    }

    public interface IMessageFactory
    {
        public IObject Create(byte[] values);
    }
}