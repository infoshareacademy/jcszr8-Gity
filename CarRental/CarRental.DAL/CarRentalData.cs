using CarRental.DAL.Models;
using Newtonsoft.Json;
using System.Text.Json;

namespace CarRental.DAL;
public static class CarRentalData
{
    public static List<CarModel> Cars { get; set; } = GetItems<CarModel>("cars.json");
    public static List<CustomerModel> Customers { get; set; } = GetItems<CustomerModel>("customers.json");
    public static List<RentalModel> Rentals { get; set; } = GetItems<RentalModel>("rentals.json");

    public static List<T> GetItems<T>(string fileName)
    {
        var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", fileName);
        string itemsSerialized = File.ReadAllText(filePath);
        return JsonConvert.DeserializeObject<List<T>>(itemsSerialized) ?? new List<T>();
    }
}
