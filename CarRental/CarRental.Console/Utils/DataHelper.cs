using CarRental.DAL.Models;
using CarRental.DAL.Utilities;
using Newtonsoft.Json;

namespace CarRental.ConsoleUI.Utils
{
    internal class DataHelper
    {
        private const string CARS_JSON_FILE_NAME = "cars.json";
        private const string CUSTOMERS_JSON_FILE_NAME = "customers.json";
        private const string RENTALS_JSON_FILE_NAME = "rentals.json";

        private const string PATH_TO_JSON_FILES = @"..\..\..\..\CarRental.DAL\Data\";

        public static void MigrateAllFromTsvToJson()
        {
            MigrateCarsFromTsvToJson("cars.tsv");
            MigrateCustomersFromTsvToJson("customers.tsv");
            MigrateRentalsFromTsvToJson("rentals.tsv");
        }
        public static void MigrateCarsFromTsvToJson(string fileName)
        {
            var reader = new CarsTSVFileReader();
            reader.ReadTsv(fileName);
            reader.LoadItems();
            List<Car> cars = reader.cars;

            string itemSerialized = ItemSerializerDeserializer<Car>.Serialize(cars);
            ItemSerializerDeserializer<Car>.WriteToJsonFile(itemSerialized, "carsSerialized.json");
        }

        public static void MigrateCustomersFromTsvToJson(string fileName)
        {
            var reader = new CustomersTSVFileReader();
            reader.ReadTsv(fileName);
            reader.LoadItems();
            List<Customer> customers = reader.customers;

            ItemSerializerDeserializer<Customer>
                .SerializeAndWriteToJsonFile(customers, "customersSerialized.json");
        }

        public static void MigrateRentalsFromTsvToJson(string fileName)
        {
            var reader = new RentalsTSVFileReader();
            reader.ReadTsv(fileName);
            reader.LoadItems();
            List<Rental> rentals = reader.rentals;

            ItemSerializerDeserializer<Rental>
                .SerializeAndWriteToJsonFile(rentals, "rentalsSerialized.json");
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

        public static List<Customer> GetCustomers()
        {
            string filePath = PATH_TO_JSON_FILES + CUSTOMERS_JSON_FILE_NAME;
            string customersSerialized = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<Customer>>(customersSerialized) ?? new List<Customer>();
        }

        public static List<Rental> GetRentals()
        {
            string filePath = PATH_TO_JSON_FILES + RENTALS_JSON_FILE_NAME;
            string rentalsSerialized = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<Rental>>(rentalsSerialized) ?? new List<Rental>();
        }
    }
}
