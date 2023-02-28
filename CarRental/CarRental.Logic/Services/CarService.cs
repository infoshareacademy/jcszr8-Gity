using CarRental.DAL;
using CarRental.DAL.Models;

namespace CarRental.Logic.Services;

public class CarService : ICarService
{
    private static int _idCounter = CarRentalData.Cars.Max(c => c.Id);

    public List<Car> GetAll()
    {
        return CarRentalData.Cars;
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
