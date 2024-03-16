using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static airplanes.Program;

namespace airplanes
{
    public class ReadFile
    {
        public static object[] ReadDataFromFile(string filePath)
        {
            var data = new List<IAviationObject>();

            foreach (var line in File.ReadLines(filePath))
            {
                var values = line.Split(',');

                if (values.Length > 0 && !string.IsNullOrEmpty(values[0]))
                {
                    string dataType = values[0];

                    switch (dataType)
                    {
                        case "C":
                            data.Add(new CrewFactory().Create(values));
                            break;
                        case "P":
                            data.Add(new PassengerFactory().Create(values));
                            break;
                        case "CA":
                            data.Add(new CargoFactory().Create(values));
                            break;
                        case "PP":
                            data.Add(new PassengerPlaneFactory().Create(values));
                            break;
                        case "CP":
                            data.Add(new CargoPlaneFactory().Create(values));
                            break;
                        case "AI":
                            data.Add(new AirportFactory().Create(values));
                            break;
                        case "FL":
                            data.Add(new FlightFactory().Create(values));
                            break;
                        default:
                            Console.WriteLine($"Unknown data type: {dataType}");
                            break;
                    }
                }
            }

            return data.ToArray();
        }
    }
}
