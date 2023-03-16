using CarRental.DAL;
using CarRental.DAL.Models;
using System.Text;

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

    public static string CarsToTableString()
    {
        StringBuilder sb = new();
        sb.Append(String.Format("\n{0,4}.| {1,-20}| {2,-25}| {3,-10}\n", "Id", "Make", "Model", "License plate"));
        sb.Append(new String('-', sb.Length));
        sb.Append('\n');
        foreach (var car in _cars)
        {
            sb.Append($"{car.Id,4}.| {car.Make,-20}| {car.CarModel,-25}| {car.LicencePlateNumber,-10}{Environment.NewLine}");
        }
        return sb.ToString();
    }
}
