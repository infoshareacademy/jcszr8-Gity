using CarRental.DAL.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.DAL.Context;

public static class Seed
{
    public static void Initialize(ApplicationContext context)
    {
        context.Database.EnsureCreated();

        Customer[] customers = CarRentalData.Customers.ToArray();
        Car[] cars = CarRentalData.Cars.ToArray();
        Rental[] rentals = CarRentalData.Rentals.ToArray();


        if (context.Customers.Any())
        {
            return; // DB has been seeded
        }

        foreach (var customer in customers)
        {
            context.Customers.Add(customer);
        }
        context.SaveChanges();

        foreach (var car in cars)
        {
            context.Cars.Add(car);
        }
        context.SaveChanges();

        foreach (var rental in rentals)
        {
            context.Rental.Add(rental);
        }
        context.SaveChanges();

    }
}

public static class SeedData
{


    //        Transmission = "Manual",
    //        LicencePlateNumber = "GD RE01",
    //        Kilometrage = 200500,
    //        PowerInKiloWats = 97.0,
    //        FuelConsumption = "",
    //        Displacement
    //    }
    //};









}
