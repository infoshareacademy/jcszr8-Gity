using CarRental.DAL.Models;
using CarRental.DAL.Utilities;
using Newtonsoft.Json;

namespace CarRental.DAL;
public class DataMigrator
{
    private const string CARS_JSON_FILE_NAME = "cars.json";
    private const string CUSTOMERS_JSON_FILE_NAME = "customers.json";
    private const string RENTALS_JSON_FILE_NAME = "rentals.json";
    private const string PATH_TO_JSON_FILES = @"..\..\..\..\CarRental.DAL\Data\";
    private const string CARS_SERIALIZED_JSON_FILE_NAME = "carsSerialized.json";
    private const string CUSTOMERS_SERIALIZED_JSON_FILE_NAME = "customersSerialized.json";
    private const string RENTALS_SERIALIZED_JSON_FILE_NAME = "rentalsSerialized.json";

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

        string itemSerialized = ItemSerializer<Car>.Serialize(cars);
        ItemSerializer<Car>.WriteToJsonFile(itemSerialized, CARS_SERIALIZED_JSON_FILE_NAME);
    }

    public static void MigrateCustomersFromTsvToJson(string fileName)
    {
        var reader = new CustomersTSVFileReader();
        reader.ReadTsv(fileName);
        reader.LoadItems();
        List<Customer> customers = reader.customers;

        ItemSerializer<Customer>
            .SerializeAndWriteToJsonFile(customers, CUSTOMERS_SERIALIZED_JSON_FILE_NAME);
    }

    public static void MigrateRentalsFromTsvToJson(string tsvFileName)
    {
        var reader = new RentalsTSVFileReader();
        reader.ReadTsv(tsvFileName);
        reader.LoadItems();
        List<Rental> rentals = reader.rentals;

        ItemSerializer<Rental>
            .SerializeAndWriteToJsonFile(rentals, RENTALS_SERIALIZED_JSON_FILE_NAME);
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
