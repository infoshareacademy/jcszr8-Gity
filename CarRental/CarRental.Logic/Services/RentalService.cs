using CarRental.DAL.Models;
using CarRental.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Logic.Interfaces;

namespace CarRental.Logic.Services
{
    public class RentalService : IRentalService
    {
        public List<int> GetAvailableCarIds(DateTime start, DateTime end)
        {

            var cars1 = GetNotRented();
            var cars2 = GetAvailableInGivenTime(start, end);
            var allIdCars = cars1.Concat(cars2).Distinct().ToList();
            return allIdCars;
        }

        public List<Car> ListOfAvailableCarForRent(List<int> carIds)

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


        public List<int> GetNotRented()
        {
            var rentedIds = CarRentalData.Rentals.Select(r => r.CarId).ToList();
            var carIds = CarRentalData.Cars.Select(c => c.Id).ToList();

            var availableCars = carIds.Except(rentedIds).ToList();

            return availableCars;

        }

        public List<int> GetAvailableInGivenTime(DateTime start, DateTime end)
        {

            var found = CarRentalData.Rentals.Where(r =>
               (end < r.BeginDate) ||
               (start > r.EndDate)
               ).Select(r => r.CarId).ToList();
            return found;
        }
    }
}
