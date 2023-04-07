using AutoMapper;
using CarRental.DAL.Entities;
using CarRental.DAL.Repositories;
using CarRental.Logic.Services;
using CarRental.Logic.Services.IServices;

namespace UnitTesting.CarRental.Logic.Tests.Services;
public class CarRentabilityServiceTests
{
    private readonly IRentalService _rentalService;
    private readonly ICustomerService _customerService;
    private readonly ICarRentabilityService _carRentabilityService;
    private readonly IRepository<Rental> _rentalRepository;
    private readonly IMapper _mapper;
    public CarRentabilityServiceTests(IRentalService rentalService, ICustomerService customerService, ICarRentabilityService carRentabilityService, IRepository<Rental> rentalRepository, IMapper mapper)
    {
        _rentalService = rentalService;
        _customerService = customerService;
        _carRentabilityService = carRentabilityService;
        _rentalRepository = rentalRepository;
        _mapper = mapper;
    }

    [Fact]
    public void GetRentalTotalPrice()
    {
        // Arrange
        decimal price = 100;
        var startDate = DateTime.Now;
        var endDate = DateTime.Now.AddDays(2);

        // Act
        decimal result = _rentalService.GetRentalTotalPrice(price, startDate, endDate);

        // Assert
        Assert.Equal(200, result);
    }


}
