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
    private readonly ICarRentabilityService _carRentabilityService;
    private readonly IRepository<Rental> _rentalRepository;
    private readonly IMapper _mapper;

    public RentalService(ICarService carService, IMapper mapper, IRepository<Rental> rentalRepository, ICustomerService customerService, ICarRentabilityService carRentabilityService)
    {
        _carService = carService;
        _customerService = customerService;
        _mapper = mapper;
        _rentalRepository = rentalRepository;
        _carRentabilityService = carRentabilityService;
    }

    public List<RentalDto> GetAll()
    {
        var rentals = _rentalRepository.GetAll();

        return _mapper.Map<List<RentalDto>>(rentals);
    }

    public RentalDto Get(int id)
    {
        var rental = _rentalRepository.Get(id);
        return _mapper.Map<RentalDto>(rental);
    }

    public void Create(RentalDto model)
    {
        if (IsRentalValidForCreate(model))
        {
            var rental = _mapper.Map<Rental>(model);
            _rentalRepository.Insert(rental);
        }
    }

    private bool IsRentalValidForCreate(RentalDto model)
    {
        if (model is null)
        {
            return false;
        }
        if (model.BeginDate >= model.EndDate)
        {
            return false;
        }
        if (_carRentabilityService.IsCarBookedForRentInGivenTerm(
            model.CarId, model.BeginDate, model.EndDate))
        {
            return false;
        }
        return true;
    }

    public void Update(RentalDto model)
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

    private IEnumerable<RentalDto> GetCollectionByPredicate(Func<RentalDto, bool> predicate)
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
        var availableCarIds = _carRentabilityService.GetIdsForCarsAvailableInGivenTerm(startDate, endDate);
        return availableCarIds.ToList();
    }

    private double CalculateDaysBetweenDates(DateTime startDate, DateTime endDate)
    {
        var days = (endDate - startDate).TotalDays;
        return days;
    }
}
