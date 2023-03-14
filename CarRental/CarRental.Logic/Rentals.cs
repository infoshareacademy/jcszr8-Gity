﻿using CarRental.DAL;
using CarRental.DAL.Models;

namespace CarRental.Logic;

public class Rentals
{
    public static List<int> GetAvailableCarIds(DateTime start, DateTime end)
    {

        var cars1 = GetNotRented();
        var cars2 = GetAvailableInGivenTime(start, end);
        var allIdCars = cars1.Concat(cars2).Distinct().ToList();
        return allIdCars;
    }

    public static List<Car> ListOfAvailableCarForRent(List<int> carIds)

    {
        var carsToRent = new List<Car>();

        foreach (var carId in carIds)
        {
            var car = CarRentalData.Cars.Where(c => c.Id == carId).ToList();
            foreach (var item in car)
            {
                carsToRent.Add(item);
            }
        }
        return carsToRent;
    }


    public static List<int> GetNotRented()
    {
        // zwraca te, które w ogóle nie występują  w liście wypożyczonych
        // te auta, których id nie występują w liście wypożyczonych
        var rentedIds = CarRentalData.Rentals.Select(r => r.CarId).ToList();
        var carIds = CarRentalData.Cars.Select(c => c.Id).ToList();

        var availableCars = carIds.Except(rentedIds).ToList();

        return availableCars;

    }

    public static List<int> GetAvailableInGivenTime(DateTime start, DateTime end)
    {

        var found = CarRentalData.Rentals.Where(r =>
           (end < r.BeginDate) ||
           (start > r.EndDate)
           ).Select(r => r.CarId).ToList(); // W efekcie dostaniemy listę wypożyczeń poza zadanym czasem
        return found;
    }
}
