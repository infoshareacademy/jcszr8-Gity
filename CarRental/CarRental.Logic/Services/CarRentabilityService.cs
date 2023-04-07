using AutoMapper;
using CarRental.DAL.Entities;
using CarRental.DAL.Repositories;
using CarRental.Logic.Models;
using CarRental.Logic.Services.IServices;

namespace CarRental.Logic.Services;
public class CarRentabilityService : ICarRentabilityService
{
    private readonly ICarService _carService;
    private readonly IRepository<Rental> _rentalRepository;
    private readonly IMapper _mapper;

    public CarRentabilityService(ICarService carService, IRepository<Rental> rentalRepository, IMapper mapper)
    {
        _carService = carService;
        _rentalRepository = rentalRepository;
        _mapper = mapper;
    }

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

    public bool IsCarBookedForRentInGivenTerm(int carId, DateTime startDate, DateTime endDate)
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
}
