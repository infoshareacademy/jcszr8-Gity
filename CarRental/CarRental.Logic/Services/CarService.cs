using CarRental.DAL;
using CarRental.DAL.Models;

namespace CarRental.Logic.Services;

public class CarService : ICarService
{
    private int _idCounter = CarRentalData.Cars.Max(c => c.Id);

    public List<Car> GetAll()
    {
        return CarRentalData.Cars;
    }

    public List<Car> CarByMake(string make)
    {
        List<Car> cars = new List<Car>();
        if (string.IsNullOrEmpty(make))
        {
            cars = CarRentalData.Cars;
        }
        else
        {
            cars = CarRentalData.Cars.Where(c => c.Make?.ToLower() == make.ToLower() ||
                                                 c.CarModel?.ToLower() == make.ToLower()).ToList();

        }
        return cars;
    }

    public Car GetById(int carId)
    {
        return CarRentalData.Cars.FirstOrDefault(c => c.Id == carId);
    }

    private int GetNextId()
    {
        return ++_idCounter;
    }
}
