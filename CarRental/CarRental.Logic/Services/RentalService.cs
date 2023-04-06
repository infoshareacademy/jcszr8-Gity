using AutoMapper;
using CarRental.DAL.Entities;
using CarRental.DAL.Repositories;
using CarRental.Logic.Models;
using CarRental.Logic.Services.IServices;

namespace CarRental.Logic.Services;

public class RentalService : IRentalService
{
    private readonly ICarService _carService;
    private readonly IRepository<Rental> _rentalRepository;
    private readonly IMapper _mapper;

    private List<CarModel> _cars;

    public RentalService(ICarService carService, IMapper mapper, IRepository<Rental> rentalRepository)
    {
        this._carService = carService;
        _mapper = mapper;
        _rentalRepository = rentalRepository;
    }

    public IEnumerable<int> GetAvailableCarIds(DateTime start, DateTime end)
    {
        var cars1 = GetNotRented();
        var cars2 = GetAvailableInGivenTime(start, end);
        var allIdCars = cars1.Concat(cars2).Distinct().ToList();
        return allIdCars;
    }

    public IEnumerable<CarModel> ListOfAvailableCarForRent(List<int> carIds)

    {
        List<CarModel> carsToRent = new();

        foreach (var carId in carIds)
        {
            var cars = _cars.Where(c => c.Id == carId).ToList();
            foreach (var item in cars)
            {
                carsToRent.Add(item);
            }
        }
        return carsToRent;
    }

    public IEnumerable<int> GetNotRented()
    {
        var rentedIds = _rentalRepository.GetAll()
            .Select(r => r.CarId).ToList();

        var carIds = _carService.GetAll()
            .Select(c => c.Id).ToList();

        var availableCarIds = carIds.Except(rentedIds).ToList();

        return availableCarIds;
    }

    public IEnumerable<int> GetAvailableInGivenTime(DateTime start, DateTime end)
    {
        var found = _rentalRepository.GetAll()
            .Where(r =>
           (end < r.BeginDate) ||
           (start > r.EndDate)
           ).Select(r => r.CarId).ToList();
        return found;
    }

    public List<RentalModel> GetAll()
    {
        var rentals = _rentalRepository.GetAll();
        return _mapper.Map<List<RentalModel>>(rentals);
    }

    public RentalModel Get(int id)
    {
        var rental = _rentalRepository.Get(id);
        return _mapper.Map<RentalModel>(rental);
    }

    public void RentACar(CustomerModel customer, CarModel car, DateTime rentFrom, DateTime rentTo)
    {

    }

    public void Create(RentalModel model)
    {
        var rental = _rentalRepository.Get(model.Id);
        _rentalRepository.Insert(rental);
    }

    public void Update(RentalModel model)
    {
        //var rental = Get(model.Id);

        //rental.CarId = model.CarId;
        //rental.CustomerId = model.CustomerId;
        //rental.BeginDate = model.BeginDate;
        //rental.EndDate = model.EndDate;
        //rental.TotalCost = model.TotalCost;

        if (model is not null) { 
            var rental = _mapper.Map<Rental>(model);
            _rentalRepository.Update(rental);
        }
    }

    public void Delete(int id)
    {
       _rentalRepository.Delete(id);
    }
}
