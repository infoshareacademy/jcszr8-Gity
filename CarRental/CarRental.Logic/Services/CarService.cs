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
    private readonly IRepository<Rental> _rentalRepository;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;
    private readonly IValidator<CarViewModel> _validator;

    public CarService(IRepository<Car> carRepository, IRepository<Rental> rentalRepository, IMapper mapper, ILogger<CarService> logger, IValidator<CarViewModel> validator)
    {
        _carRepository = carRepository;
        _rentalRepository = rentalRepository;
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

    public void Create(CarViewModel model)
    {
        if (!IsValidForCreate(model))
        {
            throw new Exception("Car is not valid for create");
        }
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
        if (!IsAllValid(model))
        {
            throw new ArgumentException("Car is not valid for update");
        }
        var car = _mapper.Map<Car>(model);
        _carRepository.Update(car);
        _logger.LogInformation($"Car with id {car.Id} was updated.");
    }

    public IEnumerable<CarViewModel> FindCars(IEnumerable<CarViewModel> collection, SearchFieldsModel sfModel)
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
        if (!string.IsNullOrEmpty(sfModel.ModelAndMake))
        {
            collection = FindCarByModel(collection, sfModel);
        }
        if (sfModel.ProductionYearFrom > 0 && sfModel.ProductionYearTo > 0)
        {
            collection = FindCarsByYear(collection, sfModel);
        }

        if (sfModel.StartDate != null && sfModel.EndDate != null)
        {
            collection = FindCarByDate(collection, sfModel);
        }
        return collection.ToList();
    }

    private IEnumerable<CarViewModel> FindCarsByMaker(IEnumerable<CarViewModel> collection, SearchFieldsModel sfModel)
    {
        var selectedMakes = sfModel.Makes.Where(m => m.Value == true).Select(m => m.Key);
        collection = GetAll()
            .Where(c => selectedMakes.Contains(c.Make, StringComparer.CurrentCultureIgnoreCase)).ToList();
        return collection.ToList();
    }

    private IEnumerable<CarViewModel> FindCarsByYear(IEnumerable<CarViewModel> collection, SearchFieldsModel sfModel)
    {
        collection = collection.Where(c => c.Year >= sfModel.ProductionYearFrom && c.Year <= sfModel.ProductionYearTo).ToList();
        return collection.ToList();
    }

    private IEnumerable<CarViewModel> FindCarByModel(IEnumerable<CarViewModel> collection, SearchFieldsModel sfModel)
    {
        collection = collection.Where(c => c.Make.Contains(sfModel.ModelAndMake.Trim(), StringComparison.CurrentCultureIgnoreCase) ||
                                         c.CarModelProp.Contains(sfModel.ModelAndMake.Trim(), StringComparison.CurrentCultureIgnoreCase)).ToList();
        return collection.ToList();
    }

    private IEnumerable<CarViewModel> FindCarByDate(IEnumerable<CarViewModel> collection, SearchFieldsModel sfModel)
    {
        var availableCarIds = GetAvailableCarIdsForSearch(sfModel.StartDate,sfModel.EndDate);
        collection = collection.Where(c => availableCarIds.Contains(c.Id));

        return collection.ToList();
    }

    private IEnumerable<int> GetAvailableCarIdsForSearch(DateTime start, DateTime end)
    {
        var cars1 = GetNotRentedForSearch();
        var cars2 = GetAvailableInGivenTimeForSearch(start, end);
        var allIdCars = cars1.Concat(cars2).Distinct().ToList();
        return allIdCars;
    }
    private IEnumerable<int> GetNotRentedForSearch()
    {
        var rentedIds = _rentalRepository.GetAll()
            .Select(r => r.CarId).ToList();

        var carIds = GetAll()
            .Select(c => c.Id).ToList();

        var availableCarIds = carIds.Except(rentedIds).ToList();

        return availableCarIds;
    }

    private IEnumerable<int> GetAvailableInGivenTimeForSearch(DateTime start, DateTime end)
    {
        var found = _rentalRepository.GetAll()
            .Where(r =>
                (end < r.BeginDate) ||
                (start > r.EndDate)
            ).Select(r => r.CarId).ToList();
        return found;
    }

    #region Validation
    private bool IsValidForCreate(CarViewModel car)
    {
        var validationResult = _validator.Validate(car, options =>
        {
            options.IncludeRuleSets("CarCreate");
        });
        LogErrors(validationResult);
        return validationResult.IsValid;
    }
    private bool IsAllValid(CarViewModel car)
    {
        var validationResult = _validator.Validate(car, options =>
        {
            options.IncludeAllRuleSets();
        });
        LogErrors(validationResult);
        return validationResult.IsValid;
    }

    private void LogErrors(ValidationResult validationResult)
    {
        foreach (var failure in validationResult.Errors)
        {
            _logger.LogInformation("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
        }
    }
    #endregion Validation
}
