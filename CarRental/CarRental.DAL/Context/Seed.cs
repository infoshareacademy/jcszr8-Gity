using CarRental.DAL.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

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
            context.Customers.Add(new()
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                PhoneNumber = customer.PhoneNumber,
                EmailAddress = customer.EmailAddress,
                Gender = customer.Gender,
                Pesel = customer.Pesel,
            });
        }
        var entriesNumber = context.SaveChanges();

        string temp = string.Empty;

        foreach (var car in cars)
        {
            temp = car.Addons.Aggregate((a, b) => a + ";" + b);

            context.Cars.Add( new()
            {
                Make = car.Make,
                CarModel = car.CarModel,
                LicencePlateNumber = car.LicencePlateNumber,
                Color = car.Color,
                Year = car.Year,
                Addons = temp,
            });
        }
        context.SaveChanges();

        foreach (var rental in rentals)
        {
            context.Rentals.Add(rental);
        }
        context.SaveChanges();
    }
}
