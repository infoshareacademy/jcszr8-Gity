using CarRental.DAL.Models;
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

        if (context.Customers.Any())
        {
            return; // DB has been seeded
        }

        var customers = new Customer[]
        {
            new() { FirstName = "Alek", LastName = "Acki", PhoneNumber = "+48600100101"},
            new() { FirstName = "Bolek", LastName = "Becki", PhoneNumber = "+48600123102"},
        };

        foreach(var customer in customers)
        {
            context.Customers.Add(customer);
        }
        context.SaveChanges();

    }
}
