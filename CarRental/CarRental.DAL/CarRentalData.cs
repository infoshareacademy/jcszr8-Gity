using CarRental.DAL.Entities;
using Newtonsoft.Json;

namespace CarRental.DAL;
public class CarRentalData
{
    public static List<Customer> Customers { get; set; } = GetItems<Customer>("customers.json");
    public static List<Rental> Rentals { get; set; } = GetItems<Rental>("rentals.json");
    public static List<Car> Cars { get; set; } = GetItems<Car>("cars.json");

    //static CarRentalData()
    //{
    //    Customers = GetItems<Customer>("customers.json");
    //    Rentals = GetItems<Rental>("rentals.json");
    //    //Rentals = new List<Rental>();
    //    Cars = GetItems<Car>("cars.json");
    //    //Cars = new List<Car>();
    //    int x = 100; // TODO ??? testing
    //}

    public static List<T> GetItems<T>(string fileName)
    {
        var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", fileName);

        string itemsSerialized;
        try
        {
            itemsSerialized = File.ReadAllText(filePath);
        }
        catch (Exception)
        {
            throw new Exception("Error with serializing to string!");
        }

        var result = JsonConvert.DeserializeObject<List<T>>(itemsSerialized);
        return result ?? new List<T>();
    }
}
