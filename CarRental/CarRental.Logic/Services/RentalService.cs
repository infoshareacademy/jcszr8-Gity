using AutoMapper;
using CarRental.Common;
using CarRental.DAL.Entities;
using CarRental.DAL.Repositories;
using CarRental.Logic.Models;
using CarRental.Logic.Services.IServices;
using Microsoft.Extensions.Logging;

namespace CarRental.Logic.Services;

public class RentalService : IRentalService
{
    private readonly ICarService _carService;
    private readonly ICustomerService _customerService;
    private readonly IRepository<Rental> _rentalRepository;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;

    public RentalService(ICarService carService, IMapper mapper, IRepository<Rental> rentalRepository,
        ICustomerService customerService, ILogger<RentalService> logger)
    {
        _carService = carService;
        _customerService = customerService;
        _rentalRepository = rentalRepository;
        _mapper = mapper;
        _logger = logger;
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
        if (IsRentalValidForCreate(model))
        {
            var rental = _mapper.Map<Rental>(model);
            _rentalRepository.Insert(rental);
            _logger.LogInformation($"Rental for car with id {model.CarId} and customer with id {model.CustomerId} was created.");
        }
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

    public void Update(RentalViewModel model)
    {
        if (model is not null)
        {
            var rental = _mapper.Map<Rental>(model);
            _logger.LogInformation($"Rental with id {model.Id} was updated.");
            _rentalRepository.Update(rental);
        }
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


    #region Fast Fix for car search

    public IEnumerable<int> GetAvailableCarIdsForSearch(Term wantedTerm)
    {
        var cars1 = GetNotRentedForSearch();
        var cars2 = GetIdsForCarsAvailableInTerm(wantedTerm);
        var allIdCars = cars1.Concat(cars2).Distinct().ToList();
        return allIdCars;
    }
    public IEnumerable<int> GetNotRentedForSearch()
    {
        var rentedIds = _rentalRepository.GetAll()
            .Select(r => r.CarId).ToList();

        var carIds = _carService.GetAll()
            .Select(c => c.Id).ToList();

        var availableCarIds = carIds.Except(rentedIds).ToList();

        return availableCarIds;
    }

    #endregion

    #region Checking Car Rentability

    private bool IsCarBookedInTerm(int carId, Term wantedTerm)
    {
        return GetCollidingWith(wantedTerm)
            .Where(r => r.CarId == carId)
            .Select(r => r.CarId)
            .Contains(carId);
    }

    public IEnumerable<RentalViewModel> GetCollidingWith(Term wantedTerm)
    {
        var collidingRentals = GetAll().Where(r =>
        {
            var term = new Term(r.BeginDate, r.EndDate);
            return term.IsCollidingWith(wantedTerm);
        });
        return collidingRentals;
    }

    public IEnumerable<RentalViewModel> GetNotCollidingWith(Term wantedTerm)
    {
        var rentals = GetAll();
        return rentals.Where(r =>
        {
            var term = new Term(r.BeginDate, r.EndDate);
            return !term.IsCollidingWith(wantedTerm);
        });
    }

    public IEnumerable<RentalViewModel> GetRentalsByCarId(int carId)
    {
        var rentals = GetAll();
        return rentals.Where(r => r.CarId == carId);
    }

    #endregion

    #region To be used
    private IEnumerable<RentalViewModel> GetByPredicate(Func<RentalViewModel, bool> predicate)
    {
        var rentals = GetAll();
        return rentals.Where(predicate);
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
    #endregion
}
