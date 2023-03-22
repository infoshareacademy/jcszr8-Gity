using AutoMapper;
using CarRental.DAL;
using CarRental.DAL.Entities;
using CarRental.DAL.Repositories;
using CarRental.Logic.Models;
using CarRental.Logic.Services.IServices;

namespace CarRental.Logic.Services;

public class CarService : ICarService
{
    private readonly IRepository<Car> _carRepository;
    private readonly IMapper _mapper;

    public CarService(IRepository<Car> carRepository, IMapper mapper)
    {
        _carRepository = carRepository;
        _mapper = mapper;
    }

    public IEnumerable<CarModel> GetAll()
    {
        var cars = _carRepository.GetAll();

        return _mapper.Map<List<CarModel>>(cars);
    }

    public IEnumerable<CarModel> GetByName(string name)
    {
        List<CarModel> cars = new();
        if (string.IsNullOrEmpty(name))
        {
            cars = GetAll().ToList();
        }
        else
        {
           var temp = _carRepository.GetAll()
                .Where(c => c.Make.Contains(name, StringComparison.CurrentCultureIgnoreCase)
                || c.CarModel.Contains(name, StringComparison.CurrentCultureIgnoreCase)
            ).ToList();

            cars = _mapper.Map<List<CarModel>>(temp);
        }
        return cars;
    }

    public List<CarModel> GetByYear(string read)
    {
        int year;
        bool makes = int.TryParse(read, out year);
        List<CarModel> cars = new();
        if (read == null)
        {
            cars = GetAll().ToList();
        }
        else
        {
            cars = GetAll().Where(c => c.Year == year || c.CarModel.ToLower().Contains(read.ToLower())).ToList();
        }
        return cars;
    }

    public List<CarModel> GetByAddons(string addon)
    {
        List<CarModel> cars = new List<CarModel>();
        if (string.IsNullOrEmpty(addon))
        {
            cars = _mapper.Map<List<CarModel>>(_carRepository.GetAll());
        }
        else
        {
            foreach (var car in _carRepository.GetAll())
            {

                foreach (var item in car.Addons.Split(";"))
                {
                    if (item.Contains(addon))
                    {
                      //  cars.Add(car);  // TODO ?????? GetByAddons
                        break;
                    }
                }
            }

        }
        return cars;
    }

    public void Create(CarModel model)
    {
        var car = _mapper.Map<Car>(model);
        _carRepository.Insert(car);
    }

    public CarModel? Get(int carId)
    {
        return CarRentalData.Cars.FirstOrDefault(c => c.Id == carId);
    }

    public void Delete(int carId)
    {
        var car = Get(carId);
        _cars.Remove(car);
    }

    private int GetNextId()
    {
        return ++_idCounter;
    }

    public void Update(CarModel model)
    {
        var car = GetById(model.Id);

        car.CarModel = model.CarModel;
        car.Make = model.Make;
        car.Kilometrage = model.Kilometrage;
        car.Year = model.Year;
        car.Airbags = model.Airbags;
        car.Addons = model.Addons;
        car.Color = model.Color;
        car.Doors = model.Doors;
        car.Displacement = model.Displacement;
        car.EngineType = model.EngineType;
        car.FuelConsumption = model.FuelConsumption;
        car.LicencePlateNumber = model.LicencePlateNumber;
        car.SeatsNo = model.SeatsNo;
        car.PowerInKiloWats = model.PowerInKiloWats;
        car.Price = model.Price;
        car.Transmission = model.Transmission;
    }
}
