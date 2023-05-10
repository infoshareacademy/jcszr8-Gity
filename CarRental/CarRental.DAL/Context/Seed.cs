﻿using AutoMapper;
using CarRental.Common.Enums;
using CarRental.DAL.Entities;
using CarRental.DAL.HelperMappings;
using CarRental.DAL.HelperModels;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Globalization;

namespace CarRental.DAL.Context;

public static class Seed
{
    public static List<CustomerJson> Customers { get; set; } = GetItems<CustomerJson>("customers.json");
    public static List<RentalJson> Rentals { get; set; } = GetItems<RentalJson>("rentals.json");
    public static List<CarJson> Cars { get; set; } = GetCarsWithJsonEmbeddedValues("cars.json");

    public static async Task Initialize(ApplicationContext context,
        UserManager<Customer> userManager, RoleManager<IdentityRole<int>> roleManager)
    {
        context.Database.EnsureCreated();

        Customer[] customers = MapperFromJson.MapToCustomers(Customers).ToArray();
        Rental[] rentals = MapperFromJson.MapToRentals(Rentals).ToArray();
        Car[] cars = MapperFromJson.MapToCars(Cars).ToArray();

        string adminRole = "Admin";
        string memberRole = "Member";
        string tempPasswordForAll = "Password@23"; //TODO password setup

        if (context.Rentals.Any() && context.Cars.Any())
        {
            return; // DB has been seeded
        }

        if (await roleManager.FindByNameAsync(adminRole) == null)
        {
            await roleManager.CreateAsync(new IdentityRole<int>(adminRole));
        }

        if (await roleManager.FindByNameAsync(memberRole) == null)
        {
            await roleManager.CreateAsync(new IdentityRole<int>(memberRole));
        }

        IdentityResult result;
        int counter = 1;
        foreach (var customer in customers)
        {
            var user = new Customer
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                PhoneNumber = customer.PhoneNumber,
                EmailAddress = customer.EmailAddress,
                Email = customer.EmailAddress,
                EmailConfirmed = true,
                Gender = customer.Gender,
                Pesel = customer.Pesel,
                UserName = customer.EmailAddress,
            };

            result = await userManager.CreateAsync(user);
            if (result.Succeeded)
            {
                await userManager.AddPasswordAsync(user, tempPasswordForAll);
                await userManager.AddToRoleAsync(user, memberRole);
            }
        }

        #region seed admin
        var adminUser = new Customer
        {
            FirstName = "Admin",
            LastName = "Adminski",
            PhoneNumber = "666666666",
            EmailAddress = "admin@example.com", //TODO email address
            Email = "admin@example.com",
            Gender = Gender.Male,
            Pesel = "80020210345",
            UserName = "admin@example.com",
            EmailConfirmed = true,
        };

        result = await userManager.CreateAsync(adminUser);

        if (result.Succeeded)
        {
            await userManager.AddPasswordAsync(adminUser, "Admin@23");
            await userManager.AddToRoleAsync(adminUser, adminRole);
        }
        #endregion seed admin

        foreach (var car in cars)
        {
            car.Id = 0; // to allow Id to be generated by DB
            car.LicencePlateNumber = new string(car.LicencePlateNumber.ToCharArray()
                .Where(c => !char.IsWhiteSpace(c)).ToArray());
            await context.Cars.AddAsync(car);
        }
        await context.SaveChangesAsync();

        foreach (var rental in rentals)
        {
            await context.Rentals.AddAsync(new Rental
            {
                CarId = rental.CarId,
                CustomerId = rental.CustomerId,
                BeginDate = rental.BeginDate,
                EndDate = rental.EndDate,
                TotalCost = rental.TotalCost,
            });
        }
        await context.SaveChangesAsync();
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

    public static List<CarJson> GetCarsWithJsonEmbeddedValues(string fileName)
    {
        var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", fileName);
        string itemsSerialized;
        string itemsSerializedWithCarsTag;
        try
        {
            itemsSerialized = File.ReadAllText(filePath);
        }
        catch (Exception)
        {
            throw new Exception("Error with serializing to string!");
        }

        var prepopulatedCars = JsonConvert.DeserializeObject<List<CarJson>>(itemsSerialized);

        #region Complete Car with embedded values from JSON file

        itemsSerializedWithCarsTag = "{\"cars\": " + itemsSerialized + "\n}";
        JObject jsonObject = JObject.Parse(itemsSerializedWithCarsTag);
        IList<JToken> jsonCars = jsonObject["cars"]!.Children().ToList();

        var selectedValues = jsonCars.Select(car => new
        {
            Displacement = car["engine_parameters"]!["displacement"]!.ToString(),
            PowerInKiloWatts = car["engine_parameters"]!["power_kw"]!.ToString(),
            FuelType = car["engine_parameters"]!["fuel_type"]!.ToString(),

            FuelConsumptionHighway = float.Parse(car["fuel_consumption_highway"]!.ToString()).ToString(CultureInfo.InvariantCulture),
            FuelConsumptionCity = float.Parse(car["fuel_consumption_city"]!.ToString()).ToString(CultureInfo.InvariantCulture),
        }).ToList();

        Dictionary<int, EngineType> jsonFuelTypeToCarEngineTypeTranslator = new()
        {
            [1] = EngineType.Gasoline,
            [2] = EngineType.Electric,
        };

        var zipped = prepopulatedCars!.Zip(selectedValues);
        foreach (var car in zipped)
        {
            car.First.Displacement = car.Second.Displacement;
            car.First.PowerInKiloWatts = float.Parse(car.Second.PowerInKiloWatts);
            car.First.EngineType = jsonFuelTypeToCarEngineTypeTranslator[int.Parse(car.Second.FuelType)];
            car.First.FuelConsumption = car.Second.FuelConsumptionHighway + "/" + car.Second.FuelConsumptionCity;
        }
        #endregion

        var result = zipped.Select(z => z.First).ToList();

        return result ?? new List<CarJson>();
    }
}

public static class Helper
{
    private static IMapper Mapper;
    public static void MappingHelper()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<CarJson, Car>();
        });
        Mapper = config.CreateMapper();
    }
    public static DestinationClass Map(SourceClass source)
    {
        return Mapper.Map<SourceClass, DestinationClass>(source);
    }
}
public class SourceClass
{
    public string Name { get; set; }
}
public class DestinationClass
{
    public string Name { get; set; }
}
