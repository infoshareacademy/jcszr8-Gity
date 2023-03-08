using CarRental.DAL;
using CarRental.DAL.Models;

namespace CarRental.Logic.Services;

public class CarService : ICarService
{
    private static int _idCounter = CarRentalData.Cars.Max(c => c.Id);
    private List<Car> _cars = CarRentalData.Cars;

    public List<Car> GetAll()
    {
        return CarRentalData.Cars;
    }

    public List<Car> CarByName(string name)
    {
        List<Car> cars = new List<Car>();
        if (string.IsNullOrEmpty(name))
        {
            cars = CarRentalData.Cars;
        }
        else
        {

            cars = CarRentalData.Cars.Where(c => c.Make.Contains(name, StringComparison.CurrentCultureIgnoreCase)
                || c.CarModel.Contains(name, StringComparison.CurrentCultureIgnoreCase)
            ).ToList();
        }
        return cars;
    }

    public List<Car> CarByYear(string read)
    {
        int year;
        bool makes = int.TryParse(read, out year);
        List<Car> cars = new List<Car>();
        if (read == null)
        {
            cars = CarRentalData.Cars;
        }
        else
        {
            cars = CarRentalData.Cars.Where(c => c.Year == year || c.CarModel.ToLower().Contains(read.ToLower())).ToList();
        }
        return cars;
    }

    public List<Car> CarByAddons(string addon)
    {
        List<Car> cars = new List<Car>();
        if (string.IsNullOrEmpty(addon))
        {
            cars = CarRentalData.Cars;
        }
        else
        {
            foreach (var car in CarRentalData.Cars)
            {
                foreach (var item in car.Addons)
                {
                    if (item.Contains(addon))
                    {
                        cars.Add(car);
                        break;
                    }
                }
            }

        }
        return cars;
    }

    public void Create(Car car)
    {
        car.Id = GetNextId();
        CarRentalData.Cars.Add(car);
    }

    public Car GetById(int carId)
    {
        return CarRentalData.Cars.FirstOrDefault(c => c.Id == carId);
    }

    public void Delete(int carId)
    {
        var car = GetById(carId);
        _cars.Remove(car);
    }

    private int GetNextId()
    {
        return ++_idCounter;
    }

    public void Update(Car model)
    {
        var car = GetById(model.Id);

        car.CarModel = model.CarModel;
        //TODO dokończyć
    }
}
