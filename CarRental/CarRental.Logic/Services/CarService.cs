using AutoMapper;
using CarRental.DAL.Entities;
using CarRental.DAL.Repositories;
using CarRental.Logic.Models;
using CarRental.Logic.Services.IServices;

namespace CarRental.Logic.Services;

public class CarService : ICarService
{
    private readonly IRepository<Car> _carRepository;
    private readonly IAddonService _addonService;
    private readonly IMapper _mapper;

    public CarService(IRepository<Car> carRepository, IMapper mapper, IAddonService addonService)
    {
        _carRepository = carRepository;
        _addonService = addonService;
        _mapper = mapper;
    }

    public IEnumerable<CarDto> GetAll()
    {
        var cars = _carRepository.GetAll();

        return _mapper.Map<List<CarDto>>(cars);
    }

    public IEnumerable<CarDto> GetByName(string name)
    {
        List<CarDto> cars = new();
        if (string.IsNullOrEmpty(name))
        {
            cars = GetAll().ToList();
        }
        else
        {
            var temp = _carRepository.GetAll()
                 .Where(c => c.Make.Contains(name, StringComparison.CurrentCultureIgnoreCase)
                 || c.CarModelProp.Contains(name, StringComparison.CurrentCultureIgnoreCase)
             ).ToList();

            cars = _mapper.Map<List<CarDto>>(temp);
        }
        return cars;
    }

    public List<CarDto> GetByYear(string read)
    {
        int year;
        bool makes = int.TryParse(read, out year);
        List<CarDto> cars = new();
        if (read == null)
        {
            cars = GetAll().ToList();
        }
        else
        {
            cars = GetAll().Where(c => c.Year == year || c.CarModelProp.ToLower().Contains(read.ToLower())).ToList();
        }
        return cars;
    }

    public void AddAddonsToCar(List<string> addonsToAdd, int carId)
    {
        var car = Get(carId);
        foreach (var addon in addonsToAdd)
        {
            car.Addons.Add(addon);
        }
    }

    public void Create(CarDto model)
    {
        var car = _mapper.Map<Car>(model);
        _carRepository.Insert(car);
    }

    public CarDto? Get(int id)
    {
        var car = _carRepository.Get(id);

        if (car == null)
        {
            throw new Exception("Invalid ID");
        }
        return _mapper.Map<CarDto>(car);
    }

    public void Delete(int id)
    {
        _carRepository.Delete(id);
    }

    public void Update(CarDto model)
    {
        var car = _mapper.Map<Car>(model);

        _carRepository.Update(car);
    }
}
