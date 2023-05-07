using AutoMapper;
using CarRental.Common;
using CarRental.DAL.Entities;
using CarRental.DAL.Repositories;
using CarRental.Logic.Models;
using CarRental.Logic.Services.IServices;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.Extensions.Logging;
using System.Runtime.CompilerServices;

namespace CarRental.Logic.Services;

public class RentalService : IRentalService
{
    private readonly ICarService _carService;
    private readonly IRepository<Rental> _rentalRepository;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;
    private readonly IValidator<RentalViewModel> _validator;

    public RentalService(ICarService carService, IMapper mapper, IRepository<Rental> rentalRepository,
        ILogger<RentalService> logger, IValidator<RentalViewModel> validator)
    {
        _carService = carService;
        _rentalRepository = rentalRepository;
        _mapper = mapper;
        _logger = logger;
        _validator = validator;
    }

    public List<RentalViewModel> GetAll()
    {
        var rentals = _rentalRepository.GetAll();
        return _mapper.Map<List<RentalViewModel>>(rentals);
    }

    public RentalViewModel Get(int id)
    {
        var rental = _rentalRepository.Get(id);
        return _mapper.Map<RentalViewModel>(rental);
    }

    public void Create(RentalViewModel model)
    {
        if (!(IsRentalValidForCreate(model) && IsAllValid(model)))
        {
            throw new ArgumentException("Rental is not valid for create");
        }
        var rental = _mapper.Map<Rental>(model);
        _rentalRepository.Insert(rental);
        _logger.LogInformation($"Rental for car with id {model.CarId} and customer with id {model.CustomerId} was created.");
    }

    public void Update(RentalViewModel model)
    {
        if (model is null || !IsAllValid(model))
        {
            throw new ArgumentException("Rental is not valid for update");
        }
        var rental = _mapper.Map<Rental>(model);
        _logger.LogInformation($"Rental with id {model.Id} was updated.");
        _rentalRepository.Update(rental);
    }

    public void Delete(int id)
    {
        _rentalRepository.Delete(id);
        _logger.LogInformation($"Rental with id {id} was deleted.");
    }

    public decimal GetRentalTotalPrice(decimal pricePerDay, DateTime rentStart, DateTime rentEnd)
    {
        // executed with ajax
        var term = new Term(rentStart, rentEnd);
        var totalPrice = pricePerDay * (decimal)term.Interval.TotalDays;
        return totalPrice;
    }

    public IEnumerable<int> GetIdsForCarsAvailableInTerm(Term wantedTerm)
    {
        var allNotCollidingRentals = GetNotCollidingWith(wantedTerm);
        var availableCarIds = allNotCollidingRentals.Select(r => r.CarId)
            .ToHashSet<int>().ToList<int>();
        return availableCarIds;
    }

    public bool IsCarBookedInTerm(int carId, Term wantedTerm)
    {
        return GetCollidingWith(wantedTerm)
            .Where(r => r.CarId == carId)
            .Select(r => r.CarId)
            .Contains(carId);
    }

    public IEnumerable<RentalViewModel> GetByCarId(int carId)
    {
        var rentals = GetAll();
        return rentals.Where(r => r.CarId == carId);
    }

    public IEnumerable<CarViewModel> GetCarsAvailableInTerm(Term wantedTerm)
    {
        var availableCarIds = GetIdsForCarsAvailableInTerm(wantedTerm);
        var cars = _carService.GetAll().Where(c => availableCarIds.Contains(c.Id)).ToList();
        return cars;
    }

    public IEnumerable<T> FilterByPredicate<T>(IQueryable<T> collection, Func<T, bool> predicate)
    {
        return collection.Where(predicate);
    }

    public bool IsCarRentedNow(int carId)
    {
        var now = DateTime.Now;
        var rentals = GetByCarId(carId);
        return rentals.Any(r => r.BeginDate <= now && r.EndDate >= now);
    }

    private bool IsRentalValidForCreate(RentalViewModel model)
    {
        if (model is null)
        {
            return false;
        }
        if (model.BeginDate >= model.EndDate)
        {
            return false;
        }
        if (IsCarBookedInTerm(model.CarId, new Term(model.BeginDate, model.EndDate)))
        {
            return false;
        }
        return true;
    }

    private IEnumerable<RentalViewModel> GetCollidingWith(Term wantedTerm)
    {
        var collidingRentals = GetAll().Where(r =>
        {
            var term = new Term(r.BeginDate, r.EndDate);
            return term.IsCollidingWith(wantedTerm);
        });
        return collidingRentals;
    }

    private IEnumerable<RentalViewModel> GetNotCollidingWith(Term wantedTerm)
    {
        var rentals = GetAll();
        return rentals.Where(r =>
        {
            var term = new Term(r.BeginDate, r.EndDate);
            return !term.IsCollidingWith(wantedTerm);
        });
    }

    private IEnumerable<RentalViewModel> GetByPredicate(Func<RentalViewModel, bool> predicate)
    {
        var rentals = GetAll();
        return rentals.Where(predicate);
    }

    #region Validation
    public bool IsAllValid(RentalViewModel rental)
    {
        var validationResult = _validator.Validate(rental, options =>
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
