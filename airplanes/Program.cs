using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Reflection.PortableExecutable;
using System.Runtime.InteropServices;
using System.Xml;
using Newtonsoft.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

using NetworkSourceSimulator;

namespace airplanes
{
    class Program
    {
        static void Main(string[] args)
        {
            LoadDataSource.LoadDatafromSource();
        }
        public static T FormatData<T>(string data)
        {
            string temp = data.ToString(System.Globalization.CultureInfo.InvariantCulture);
            T result = (T)Convert.ChangeType(temp, typeof(T), System.Globalization.CultureInfo.InvariantCulture);
            return result;
        }
        public static void SaveToJson(object[] data, string filePath)
        {
            var json = JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

    }

}