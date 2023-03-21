﻿using CarRental.DAL.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CarRental.DAL.Context;

public class Seed
{
    private readonly IMapper _mapper;

    public Seed(IMapper mapper)
    {
        _mapper = mapper;
    }
    public void Initialize(ApplicationContext context)
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
            var carDto = _mapper.Map<CarDb>(car);
            carDto.Addons = string.Join(";", car.Addons);
            context.Cars.Add(carDto);
        }
        context.SaveChanges();

        foreach (var rental in rentals)
        {
            context.Rentals.Add(rental);
        }
        context.SaveChanges();
    }
}
