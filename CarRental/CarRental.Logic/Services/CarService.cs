using CarRental.DAL;
using CarRental.DAL.Models;

namespace CarRental.Logic.Services;

public class CarService
{
    private static int _idCounter = CarRentalData.Cars.Max(c => c.Id);
    private static List<Car> _cars = CarRentalData.Cars;
    public List<Car> GetAll()
    {
        return _cars;
    }

    public Car GetById(int carId)
    {
        return _cars.FirstOrDefault(c => c.Id == carId);
    }

    private int GetNextId()
    {
        return ++_idCounter;
    }
}
