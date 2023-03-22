using CarRental.DAL.Entities;
using Newtonsoft.Json;

namespace CarRental.DAL;
public static class CarRentalData
{
    public static List<Car> Cars { get; set; } = GetItems<Car>("cars.json");
    public static List<Customer> Customers { get; set; } = GetItems<Customer>("customers.json");
    public static List<Rental> Rentals { get; set; } = GetItems<Rental>("rentals.json");

    public static List<T> GetItems<T>(string fileName)
    {
        var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", fileName);
        string itemsSerialized = File.ReadAllText(filePath);
        return JsonConvert.DeserializeObject<List<T>>(itemsSerialized) ?? new List<T>();
    }
}
