using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CarRental.DAL
{
    public static class DataReaderAndWriter
    {
        //private List<Car> cars = new();
        const string DATA_PATH = @"..\..\..\..\CarRental.DAL\Data\";
        const string CARS_JSON_FILENAME = "cars.json";

        public static List<Car> GetCarsFromJson()
        {
            List<Car> cars = new();

            string carsSerialized = File.ReadAllText(DATA_PATH + CARS_JSON_FILENAME);
            cars = JsonConvert.DeserializeObject<List<Car>>(carsSerialized);

            return cars;
        }

        public static void WriteCarsToJson()
        {
            List<string> addons1 = new List<string>() { "child seat", "dog mat", "driver airbag", "power windows front", "front-drive" };

            Car car1 = new Car
            {
                Make = "Toyota",
                Model = "Corolla",
                Year = 2015,
                Color = "Black",
                Ac = true,
                Transmission = "Manual",
                EngineType = "Diesel",
                SeatsNo = 4,
                Addons = addons1
            };

            List<string> addons2 = new List<string>() { "child seat", "front-drive" };

            Car car2 = new Car
            {
                Make = "Toyota",
                Model = "Yaris",
                Year = 2007,
                Color = "Green",
                Ac = true,
                Transmission = "Manual",
                EngineType = "Gas",
                SeatsNo = 5,
                Addons = addons2
            };

            List<Car> cars = new List<Car>() { car1, car2 };

            // serializacja

            string carsSerialized = JsonConvert.SerializeObject(cars);

            File.WriteAllText(DATA_PATH + "carsSerialized.json", carsSerialized);
        }

        public static Car GetCarFromJson()
        {
            Car car = new();
            return car;
        }

        public static List<List<string>> ReadCarsDataFromTSVFile(string filePath)
        // TSV file - file with Tab Separated Values
        {
            var carsData = File.ReadAllLines(filePath).Select(line => line.Split('\t').ToList())
                .ToList();

            return carsData;
        }
    }
}
