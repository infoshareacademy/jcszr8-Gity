using AutoMapper;
using CarRental.DAL.Entities;
using CarRental.DAL.Repositories;
using CarRental.Logic.Models;
using CarRental.Logic.Services.IServices;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.Extensions.Logging;

namespace CarRental.Logic.Services;

public class CarService : ICarService
{
    private readonly IRepository<Car> _carRepository;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;
    private readonly IValidator<CarViewModel> _validator;

    public CarService(IRepository<Car> carRepository, IMapper mapper, ILogger<CarService> logger, IValidator<CarViewModel> validator)
    {
        _carRepository = carRepository;
        _mapper = mapper;
        _logger = logger;
        _validator = validator;
    }

    public IEnumerable<CarViewModel> GetAll()
    {
        List<Car> cars = _carRepository.GetAll() ?? new List<Car>();
        var result = _mapper.Map<List<CarViewModel>>(cars);
        return result;
    }

    public IEnumerable<CarViewModel> GetByName(string name)
    {
        List<CarViewModel> cars = new();
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

            cars = _mapper.Map<List<CarViewModel>>(temp);
        }
        return cars;
    }

    public List<CarViewModel> GetByYear(string read)
    {
        int year;
        bool makes = int.TryParse(read, out year);
        List<CarViewModel> cars = new();
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

    public void Create(CarViewModel model)
    {
        var car = _mapper.Map<Car>(model);
        _carRepository.Insert(car);
        _logger.LogInformation($"Car ({car.Make}, {car.CarModelProp}, {car.Year}, {car.LicencePlateNumber}) was created.");
    }

    public CarViewModel? Get(int id)
    {
        var car = _carRepository.Get(id);

        if (car == null)
        {
            throw new Exception("Invalid ID");
        }
        return _mapper.Map<CarViewModel>(car);
    }

    public void Delete(int id)
    {
        _carRepository.Delete(id);
        _logger.LogInformation($"Car with id {id} was deleted.");
    }

    public void Update(CarViewModel model)
    {
        //ValidationResult results = _validator.Validate(model);

        //if (!results.IsValid)
        //{
        //    return;
        //}

        var car = _mapper.Map<Car>(model);
        _carRepository.Update(car);
        _logger.LogInformation($"Car with id {car.Id} was updated.");
    }

    public List<CarViewModel> FindCars(IEnumerable<CarViewModel> collection, SearchFieldsModel sfModel)
    {
        if (sfModel.Makes.Values.All(m => m == false))
        {
            var cars = GetAll();
            collection = _mapper.Map<List<CarViewModel>>(collection);
        }
        if (sfModel.Makes.Values.Contains(true))
        {
            collection = FindCarsByMaker(collection, sfModel);
        }
        if (!string.IsNullOrEmpty(sfModel.Model))
        {
            collection = FindCarByModel(collection, sfModel);
        }
        if (sfModel.ProductionYearFrom > 0 && sfModel.ProductionYearTo > 0)
        {
            collection = FindCarsByYear(collection, sfModel);
        }
        return collection.ToList();
    }

    public List<CarViewModel> FindCarsByMaker(IEnumerable<CarViewModel> collection, SearchFieldsModel sfModel)
    {
        var selectedMakes = sfModel.Makes.Where(m => m.Value == true).Select(m => m.Key);
        collection = GetAll()
            .Where(c => selectedMakes.Contains(c.Make, StringComparer.CurrentCultureIgnoreCase)).ToList();
        return collection.ToList();
    }

    public List<CarViewModel> FindCarsByYear(IEnumerable<CarViewModel> collection, SearchFieldsModel sfModel)
    {
        collection = collection.Where(c => c.Year >= sfModel.ProductionYearFrom && c.Year <= sfModel.ProductionYearTo).ToList();
        return collection.ToList();
    }

    public List<CarViewModel> FindCarByModel(IEnumerable<CarViewModel> collection, SearchFieldsModel sfModel)
    {
        collection = collection.Where(c => c.Make.Contains(sfModel.Model.Trim(), StringComparison.CurrentCultureIgnoreCase) ||
                                         c.CarModelProp.Contains(sfModel.Model.Trim(), StringComparison.CurrentCultureIgnoreCase)).ToList();
        return collection.ToList();
    }
}
