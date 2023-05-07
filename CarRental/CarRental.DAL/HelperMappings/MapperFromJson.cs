using AutoMapper;
using CarRental.DAL.Entities;
using CarRental.DAL.HelperModels;

namespace CarRental.DAL.HelperMappings;
public class MapperFromJson
{
    private static readonly IMapper _customerMapper = new Mapper(new MapperConfiguration(cfg =>
    {
        cfg.CreateMap<CustomerJson, Customer>();
        //cfg.AddProfile<CustomerJsonProfile>();
    }));

    private static readonly IMapper _carMapper = new Mapper(new MapperConfiguration(cfg =>
    {
        cfg.CreateMap<CarJson, Car>();
        cfg.AddProfile<CarJsonProfile>();
    }));

    private static readonly IMapper _rentalMapper = new Mapper(new MapperConfiguration(cfg =>
    {
        cfg.CreateMap<RentalJson, Rental>();
        cfg.AddProfile<RentalJsonProfile>();
    }));

    public static List<Car> MapToCars(List<CarJson> carsJson)
    {
        return _carMapper.Map<List<Car>>(carsJson);
    }

    public static List<Customer> MapToCustomers(List<CustomerJson> customersJson)
    {
        return _customerMapper.Map<List<Customer>>(customersJson);
    }

    public static List<Rental> MapToRentals(List<RentalJson> rentalsJson)
    {
        return _rentalMapper.Map<List<Rental>>(rentalsJson);
    }
}
