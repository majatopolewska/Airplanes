using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace airplanes
{
    public interface IAviationObject
    {
        string messageType { get; set; }
    }
    public interface IDataFactory
    {
        public IAviationObject Create(string[] values);

        public IAviationObject Parse(byte[] values);
    }
}