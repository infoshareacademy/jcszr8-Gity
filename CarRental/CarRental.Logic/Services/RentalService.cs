using CarRental.DAL.Models;
using CarRental.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Logic.Services
{
    private static int _idCounter;
    private readonly ICarService _carService;
    private List<Car> _cars;
    private List<Rental> _rentals = CarRentalData.Rentals;

    public RentalService(ICarService carService)
    {
        this._carService = carService ?? throw new ArgumentNullException(nameof(carService));

        _cars = _carService.GetAll().ToList();
        _idCounter = _rentals.Max(c => c.Id);
    }

    public IEnumerable<int> GetAvailableCarIds(DateTime start, DateTime end)
    {
        var cars1 = GetNotRented();
        var cars2 = GetAvailableInGivenTime(start, end);
        var allIdCars = cars1.Concat(cars2).Distinct().ToList();
        return allIdCars;
    }

    public IEnumerable<Car> ListOfAvailableCarForRent(List<int> carIds)

    {
        List<Car> carsToRent = new();

        foreach (var carId in carIds)
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

    public Rental GetById(int id)
    {
        return _rentals.FirstOrDefault(r => r.Id == id);
    }

    public void RentACar(Customer customer, Car car, DateTime rentFrom, DateTime rentTo)
    {

    }

    public void Create(Rental rental)
    {
        rental.Id = GetNextId();
        _rentals.Add(rental);
    }
    private int GetNextId() => ++_idCounter;

    public void Update(Rental model)
    {
        var rental = GetById(model.Id);

        rental.CarId = model.CarId;
        rental.CustomerId = model.CustomerId;
        rental.BeginDate = model.BeginDate;
        rental.EndDate = model.EndDate;
        rental.TotalCost = model.TotalCost;
    }

    public void Delete(int id)
    {
        var rental = GetById(id);
        _rentals.Remove(rental);
    }
}
