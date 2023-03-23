using CarRental.DAL.Entities;
using Newtonsoft.Json;
using System.Diagnostics;

namespace CarRental.DAL;
public class CarRentalData
{
    public static List<Customer> Customers { get; }
    public static List<Car> Cars { get; }
    public static List<Rental> Rentals { get; }

    static CarRentalData()
    {
        Customers = GetItems<Customer>("customers.json");
        Rentals = GetItems<Rental>("rentals.json");
        //Rentals = new List<Rental>();
        //Cars = GetItems<Car>("cars.json");
        Cars = new List<Car>();
    }

    public static List<T> GetItems<T>(string fileName)
    {
        var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", fileName);
        Debug.WriteLine($"--- JSON file path: {filePath}");  // TODO debug.writeline  -- to delete

        string itemsSerialized;
        try
        {
            itemsSerialized = File.ReadAllText(filePath);
            Debug.Write(itemsSerialized); // ????????
        }
        catch (Exception)
        {

            throw new Exception("Error with serializing to string!");
        }

        var result = JsonConvert.DeserializeObject<List<T>>(itemsSerialized);
        return result ?? new List<T>();
    }
}
