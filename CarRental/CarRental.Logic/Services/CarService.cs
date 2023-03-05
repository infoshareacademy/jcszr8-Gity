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

    public List<Car> SearchList(string search) 
    {
        List<Car> results = new List<Car>();
        if (int.TryParse(search, out int year))
        {
            results.AddRange(CarByYear(search));
        }
        else
        {
            results.AddRange(CarByName(search));
            results.AddRange(CarByAddons(search));
        }
        return results;
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
