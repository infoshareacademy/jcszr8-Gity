using CarRental.DAL;
using CarRental.DAL.Models;
using System.Runtime.CompilerServices;

namespace CarRental.Logic;
public class LogicCarManager
{
    private static int _idCounter = CarRentalData.Cars.Max(c => c.Id);

    private static List<Car> _cars = CarRentalData.Cars;
    public static Car CreateCar(string make, string model, string licensePlate)
    {
        int id = GetNextId();
        var car = new Car(id, make, model, licensePlate);
        CarRentalData.Cars.Add(car);
        return car;
    }

    public static Car GetById(int carId)
    {
        return _cars.FirstOrDefault(c => c.Id == carId);
    }

    private static int GetNextId()
    {
        return ++_idCounter;
    }
}
