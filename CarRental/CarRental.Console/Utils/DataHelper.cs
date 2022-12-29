using CarRental.DAL.Models;
using CarRental.DAL.Utilities;
using Newtonsoft.Json;

namespace CarRental.ConsoleUI.Utils
{
    internal class DataHelper
    {
        private const string CARS_JSON_FILE_NAME = AppConfig.CARS_JSON_FILE_NAME;
        private const string CUSTOMERS_JSON_FILE_NAME = AppConfig.CUSTOMERS_JSON_FILE_NAME;
        private const string RENTALS_JSON_FILE_NAME = AppConfig.RENTALS_JSON_FILE_NAME;
        private const string PATH_TO_JSON_FILES = AppConfig.PATH_TO_JSON_FILES;

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
            ItemSerializerDeserializer<Car>.WriteToJsonFile(itemSerialized, AppConfig.CARS_SERIALIZED_JSON_FILE_NAME);
        }

        public static void MigrateCustomersFromTsvToJson(string fileName)
        {
            var reader = new CustomersTSVFileReader();
            reader.ReadTsv(fileName);
            reader.LoadItems();
            List<Customer> customers = reader.customers;

            ItemSerializerDeserializer<Customer>
                .SerializeAndWriteToJsonFile(customers, AppConfig.CUSTOMERS_SERIALIZED_JSON_FILE_NAME);
        }

        public static void MigrateRentalsFromTsvToJson(string fileName)
        {
            var reader = new RentalsTSVFileReader();
            reader.ReadTsv(fileName);
            reader.LoadItems();
            List<Rental> rentals = reader.rentals;

            ItemSerializerDeserializer<Rental>
                .SerializeAndWriteToJsonFile(rentals, AppConfig.RENTALS_SERIALIZED_JSON_FILE_NAME);
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
