using CarRental.DAL.Models;
using CarRental.DAL.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.ConsoleUI.Utils
{
    internal class DataHelper
    {
        private const string CARS_JSON_FILE_NAME = "cars.json";
        private const string PATH_TO_JSON_FILES = @"..\..\..\..\CarRental.DAL\Data\";

        public static void MigrateAll()
        {
            MigrateCarsFromTsvToJson();
        }
        public static void MigrateCarsFromTsvToJson()
        {
            var carReader = new CarsTSVFileReader();
            carReader.ReadTsv();
            carReader.LoadItems();
            List<Car> cars = carReader.cars;

            string carsSerialized = CarSerializerDeserializer.Serialize(cars);
            CarSerializerDeserializer.WriteToJsonFile(carsSerialized);
        }

        public static void PrintListOfCars(List<Car> cars)
        {
            foreach (Car car in cars)
            {
                Console.WriteLine(car.ToString());
            }
        }

        public static List<Car> GetCars()
        {
            string filePath = PATH_TO_JSON_FILES + CARS_JSON_FILE_NAME;
            string carsSerialized = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<Car>>(carsSerialized) ?? new List<Car>();
        }
    }
}
