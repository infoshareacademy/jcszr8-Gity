using CarRental.Common.Enums;
using CarRental.DAL.Entities;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Drawing;

namespace CarRental.DAL.Context;

public static class Seed
{
    public static List<Customer> Customers { get; set; } = GetItems<Customer>("customers.json");
    public static List<Rental> Rentals { get; set; } = GetItems<Rental>("rentals.json");
    public static List<Car> Cars { get; set; } = GetItems<Car>("cars.json");

    public static void Initialize(ApplicationContext context)
    {
        context.Database.EnsureCreated();

        Customer[] customers = Customers.ToArray();
        Rental[] rentals = Rentals.ToArray();
        PopulateAddons();
        Car[] cars = Cars.ToArray();

        if (context.Customers.Any() && context.Rentals.Any())
        {
            return; // DB has been seeded
        }

        foreach (var customer in customers)
        {
            context.Customers.Add(new()
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                PhoneNumber = customer.PhoneNumber,
                EmailAddress = customer.EmailAddress,
                Gender = customer.Gender,
                Pesel = customer.Pesel,
            });

            // TODO cleaning
            //var customerDb = CustomerDbBuilder.aCustomerDb()
            //    .WithFirstName(customer.FirstName)
            //    .WithLastName(customer.LastName)
            //    .WithPhoneNumber(customer.PhoneNumber)
            //    .Build();
            //context.Customers.Add(customerDb);
        }
        context.SaveChanges();

        foreach (var car in cars)
        {
            var newCar = FillCarModel(car);
            context.Cars.Add(newCar);
        }
        context.SaveChanges();

        foreach (var rental in rentals)
        {
            context.Rentals.Add(new Rental
            {
                CarId = rental.CarId,
                CustomerId = rental.CustomerId,
                BeginDate = rental.BeginDate,
                EndDate = rental.EndDate,
                TotalCost = rental.TotalCost,
            });
        }
        context.SaveChanges();
    }

    public static void PopulateAddons()
    {
        foreach (var car in Cars)
        {
            car.PopulateAddonsFromAddonHelper();
        }
    }

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

    private static Car FillCarModel(Car car)
    {
        return new Car()
        {
            //Id = 0,
            CarModelProp = car.CarModelProp,
            Make = car.Make,
            LicencePlateNumber = car.LicencePlateNumber,
            Year = car.Year,
            Color = car.Color,
            Displacement = car.Displacement,
            EngineType = car.EngineType,
            Kilometrage = car.Kilometrage,
            Addons = car.Addons,
            Airbags = car.Airbags,
            Doors = car.Doors,
            FuelConsumption = car.FuelConsumption,
            PowerInKiloWats = car.PowerInKiloWats,
            Price = car.Price,
            SeatsNo = car.SeatsNo,
            Transmission = car.Transmission,
        };
    }
}
