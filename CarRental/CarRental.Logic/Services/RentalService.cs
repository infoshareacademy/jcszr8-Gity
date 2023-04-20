using AutoMapper;
using CarRental.DAL.Entities;
using CarRental.DAL.Repositories;
using CarRental.Logic.Models;
using CarRental.Logic.Services.IServices;

namespace CarRental.Logic.Services;

public class RentalService : IRentalService
{
    private readonly ICarService _carService;
    private readonly ICustomerService _customerService;
    private readonly IRepository<Rental> _rentalRepository;
    private readonly IMapper _mapper;

    public RentalService(ICarService carService, IMapper mapper, IRepository<Rental> rentalRepository, ICustomerService customerService)
    {
        _carService = carService;
        _customerService = customerService;
        _mapper = mapper;
        _rentalRepository = rentalRepository;
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
        if (IsCarBookedForRentInGivenTerm(
            model.CarId, model.BeginDate, model.EndDate))
        {
            return false;
        }
        return true;
    }

    public void Update(RentalViewModel model)
    {
        //var rental = Get(model.Id);

        //rental.CarId = model.CarId;
        //rental.CustomerId = model.CustomerId;
        //rental.BeginDate = model.BeginDate;
        //rental.EndDate = model.EndDate;
        //rental.TotalCost = model.TotalCost;

        if (model is not null)
        {
            var rental = _mapper.Map<Rental>(model);
            _rentalRepository.Update(rental);
        }
    }

    public void Delete(int id)
    {
        _rentalRepository.Delete(id);
    }

    private IEnumerable<RentalViewModel> GetCollectionByPredicate(Func<RentalViewModel, bool> predicate)
    {
        var rentals = GetAll();
        return rentals.Where(predicate);
    }

    public decimal GetRentalTotalPrice(decimal pricePerDay, DateTime rentStart, DateTime rentEnd)
    {
        var totalPrice = pricePerDay * (decimal)CalculateDaysBetweenDates(rentStart, rentEnd);
        return totalPrice;
    }

    public IEnumerable<T> FilterByPredicate<T>(IQueryable<T> collection, Func<T, bool> predicate)
    {
        return collection.Where(predicate);
    }

    public List<int> GetAvailableCarIds(DateTime startDate, DateTime endDate)
    {
        var availableCarIds = GetIdsForCarsAvailableInGivenTerm(startDate, endDate);
        return availableCarIds.ToList();
    }

    private double CalculateDaysBetweenDates(DateTime startDate, DateTime endDate)
    {
        var days = (endDate - startDate).TotalDays;
        return days;
    }

    #region Checking Car Rentability

    public IEnumerable<int> GetIdsForCarsAvailableInGivenTerm(DateTime startDate, DateTime endDate)
    {
        var allNotCollidingRentals = GetRentalsNotCollidingWithTerm(startDate, endDate);
        var availableCarIds = allNotCollidingRentals.Select(r => r.CarId)
            .ToHashSet<int>().ToList<int>();
        return availableCarIds;
    }

    public IEnumerable<CarViewModel> GetCarsAvailableInGivenTerm(DateTime termStart, DateTime termEnd)
    {
        var availableCarIds = GetIdsForCarsAvailableInGivenTerm(termStart, termEnd);
        var cars = _carService.GetAll().Where(c => availableCarIds.Contains(c.Id)).ToList();
        return cars;
    }

    public IEnumerable<RentalViewModel> GetRentalsNotCollidingWithTerm(DateTime termStart, DateTime termEnd)
    {
        var rentals = GetAllRentals();
        return rentals.Where(r => r.BeginDate > termEnd || r.EndDate < termStart);
    }

    public IEnumerable<RentalViewModel> GetRentalsCollidingWithTerm(DateTime startDate, DateTime endDate)
    {
        var rentals = GetAllRentals();
        return rentals.Where(r =>
            startDate < r.BeginDate && endDate > r.BeginDate
            || startDate < r.EndDate && endDate > r.EndDate
            || startDate > r.BeginDate && endDate < r.EndDate);
    }

    public bool IsCarAvailableForRentInGivenTerm(int carId, DateTime startDate, DateTime endDate)
    {
        var notCollidingRentals = GetRentalsNotCollidingWithTerm(startDate, endDate);
        var filteredCarIds = notCollidingRentals.Where(r => r.CarId == carId).Select(r => r.CarId).ToHashSet<int>().ToList<int>();
        return filteredCarIds.Contains(carId);
    }

    private bool IsCarBookedForRentInGivenTerm(int carId, DateTime startDate, DateTime endDate)
    {
        var collidingRentals = GetRentalsCollidingWithTerm(startDate, endDate);
        var filteredCarIds = collidingRentals.Where(r => r.CarId == carId).Select(r => r.CarId).ToHashSet<int>().ToList<int>();
        return filteredCarIds.Contains(carId);
    }

    private IEnumerable<RentalViewModel> GetAllRentals()
    {
        var rentals = _rentalRepository.GetAll();
        return _mapper.Map<List<RentalViewModel>>(rentals);
    }

    #endregion
}
