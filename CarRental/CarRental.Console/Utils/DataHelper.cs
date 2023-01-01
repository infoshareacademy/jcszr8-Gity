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

        public static void MigrateRentalsFromTsvToJson(string tsvFileName)
        {
            var reader = new RentalsTSVFileReader();
            reader.ReadTsv(tsvFileName);
            reader.LoadItems();
            List<Rental> rentals = reader.rentals;

            ItemSerializerDeserializer<Rental>
                .SerializeAndWriteToJsonFile(rentals, AppConfig.RENTALS_SERIALIZED_JSON_FILE_NAME);
        }

        public static void PrintListOfItems<T>(List<T> items)
        {
            foreach (T item in items)
            {
                if (item != null)
                    Console.WriteLine(item.ToString());
            }
        }

        public static List<T> GetItems<T>(string fileName)
        {
            string filePath = PATH_TO_JSON_FILES + fileName;
            string itemsSerialized = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<T>>(itemsSerialized) ?? new List<T>();
        }
    }
}
