using CarRental.DAL.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.DAL;
public static class CarRentalData
{
    public static List<Car> Cars { get; set; } = GetItems<Car>("cars.json");
    public static List<Customer> Customers { get; set; } = GetItems<Customer>("customers.json");
    public static List<Rental> Rentals { get; set; } = GetItems<Rental>("rentals.json");

    private const string PATH_TO_JSON_FILES = @"..\..\..\..\CarRental.DAL\Data\";

    public static List<T> GetItems<T>(string fileName)
    {
        string filePath = PATH_TO_JSON_FILES + fileName;
        string itemsSerialized = File.ReadAllText(filePath);
        return JsonConvert.DeserializeObject<List<T>>(itemsSerialized) ?? new List<T>();
    }
}
