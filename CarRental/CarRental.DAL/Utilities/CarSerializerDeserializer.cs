using CarRental.DAL.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.DAL.Utilities
{
    public static class CarSerializerDeserializer
    {
        private const string JSON_FILE_NAME = "carsSerialized.json";

        private const string PATH_TO_JSON_FILES = @"..\..\..\..\CarRental.DAL\Data\";

        public static string Serialize(List<Car> objects)
        {
            return JsonConvert.SerializeObject(objects);
        }

        public static List<Car> Deserialize(string carsSerialized)
        {
            return JsonConvert.DeserializeObject<List<Car>>(carsSerialized) ?? new List<Car>();
        }

        public static void WriteToJsonFile(string objectsSerialized)
        {
            string filePath = PATH_TO_JSON_FILES + JSON_FILE_NAME;
            File.WriteAllText(filePath, objectsSerialized);
        }
    }
}
