using NetTopologySuite.Noding;
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
        ulong Id { get; set; } 
    }
    public interface IDataFactory
    {
        public IAviationObject Create(string[] values);

        public IAviationObject Parse(byte[] values);
    }

    public interface IReportable
    {
        public string ReportNews(IMedia reported);
    }
    public interface IMedia
    {
        public string Visit(Airport a);
        public string Visit(CargoPlane cp);
        public string Visit(PassengerPlane pp);
    }

    public interface IObserver
    {
        void Update(ISubject subject);
    }

    public interface ISubject
    {
        void Attach(IObserver observer);
        void Detach(IObserver observer);
        void Notify();
    }

    public interface IContactInfo
    {
        public string Phone { get; set; }
        public string Email { get; set; }
    }

    public interface IPositionInfo
    {
        public Single Longitude { get; set; }
        public Single Latitude { get; set; }
        public Single AMSL { get; set; }
    }

}