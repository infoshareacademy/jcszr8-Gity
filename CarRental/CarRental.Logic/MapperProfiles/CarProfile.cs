using AutoMapper;
using CarRental.DAL.Entities;
using CarRental.DAL.HelperModels;
using CarRental.Logic.Models;
using System.Reflection;

namespace CarRental.Logic.MapperProfiles;

public class CarProfile : Profile
{
    public CarProfile()
    {
        CreateMap<Car, CarViewModel>()
            .ConvertUsing<CarToCarViewModelConverter>();
            //.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            //.ForMember(dest => dest.Make, opt => opt.MapFrom(src => src.Make))
            //.ForMember(dest => dest.CarModelProp, opt => opt.MapFrom(src => src.CarModelProp))
            //.ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Year))
            //.ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.Color))
            //.ForMember(dest => dest.Transmission, opt => opt.MapFrom(src => src.Transmission))
            //.ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
            //.ForMember(dest => dest.LicencePlateNumber, opt => opt.MapFrom(src => src.LicencePlateNumber))
            //.ForMember(dest => dest.Kilometrage, opt => opt.MapFrom(src => src.Kilometrage))
            //.ForMember(dest => dest.PowerInKiloWats, opt => opt.MapFrom(src => src.PowerInKiloWats))
            //.ForMember(dest => dest.EngineType, opt => opt.MapFrom(src => src.EngineType))
            //.ForMember(dest => dest.Displacement, opt => opt.MapFrom(src => src.Displacement))
            //.ForMember(dest => dest.Doors, opt => opt.MapFrom(src => src.Doors))
            //.ForMember(dest => dest.SeatsNo, opt => opt.MapFrom(src => src.SeatsNo))
            //.ForMember(dest => dest.Airbags, opt => opt.MapFrom(src => src.Airbags))
            //.ForMember(dest => dest.FuelConsumption, opt => opt.MapFrom(src => src.FuelConsumption))
            //.ForMember(dest => dest.Addons, opt => opt.MapFrom(src => src.Addons!.Split(";", StringSplitOptions.None).ToList()));


        CreateMap<CarViewModel, Car>()
            .ConvertUsing<CarViewModelToCarConverter>();
            //.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            //.ForMember(dest => dest.Make, opt => opt.MapFrom(src => src.Make))
            //.ForMember(dest => dest.CarModelProp, opt => opt.MapFrom(src => src.CarModelProp))
            //.ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Year))
            //.ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.Color))
            //.ForMember(dest => dest.Transmission, opt => opt.MapFrom(src => src.Transmission))
            //.ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
            //.ForMember(dest => dest.LicencePlateNumber, opt => opt.MapFrom(src => src.LicencePlateNumber))
            //.ForMember(dest => dest.Kilometrage, opt => opt.MapFrom(src => src.Kilometrage))
            //.ForMember(dest => dest.PowerInKiloWats, opt => opt.MapFrom(src => src.PowerInKiloWats))
            //.ForMember(dest => dest.EngineType, opt => opt.MapFrom(src => src.EngineType))
            //.ForMember(dest => dest.Displacement, opt => opt.MapFrom(src => src.Displacement))
            //.ForMember(dest => dest.Doors, opt => opt.MapFrom(src => src.Doors))
            //.ForMember(dest => dest.SeatsNo, opt => opt.MapFrom(src => src.SeatsNo))
            //.ForMember(dest => dest.Airbags, opt => opt.MapFrom(src => src.Airbags))
            //.ForMember(dest => dest.FuelConsumption, opt => opt.MapFrom(src => src.FuelConsumption))
            //.ForMember(dest => dest.Addons, opt => opt.MapFrom(src => string.Join(";", src.Addons)));
    }

}


public class CarToCarViewModelConverter : ITypeConverter<Car, CarViewModel>
{
    public CarViewModel Convert(Car source, CarViewModel destination, ResolutionContext context)
    {
        CarViewModel car;

        List<string> addons;
        try
        {
            addons = source.Addons.Split(", ").ToList();
        }
        catch (Exception ex)
        {
            addons = new List<string>() { "ERROR" };
        }

        try
        {
            car = new CarViewModel
            {
                Addons = addons,
                Id = source.Id,
                Make = source.Make,
                CarModelProp = source.CarModelProp,
                Year = source.Year,
                Color = source.Color,
                Transmission = source.Transmission,
                LicencePlateNumber = source.LicencePlateNumber,
                Kilometrage = source.Kilometrage,
                PowerInKiloWats = source.PowerInKiloWats,
                EngineType = source.EngineType,
                Displacement = source.Displacement,
                Doors = source.Doors,
                SeatsNo = source.SeatsNo,
                Airbags = source.Airbags,
                FuelConsumption = source.FuelConsumption,
                Price = source.Price,
            };
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
        return car;
    }
}

public class CarViewModelToCarConverter : ITypeConverter<CarViewModel, Car>
{
    public Car Convert(CarViewModel source, Car destination, ResolutionContext context)
    {
        Car car;
        try
        {
            car = new Car
            {
                Addons = string.Join(", ", source.Addons),
                Id = source.Id,
                Make = source.Make,
                CarModelProp = source.CarModelProp,
                Year = source.Year,
                Color = source.Color,
                Transmission = source.Transmission,
                LicencePlateNumber = source.LicencePlateNumber,
                Kilometrage = source.Kilometrage,
                PowerInKiloWats = source.PowerInKiloWats,
                EngineType = source.EngineType,
                Displacement = source.Displacement,
                Doors = source.Doors,
                SeatsNo = source.SeatsNo,
                Airbags = source.Airbags,
                FuelConsumption = source.FuelConsumption,
                Price = source.Price,
            };
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
        return car;
    }
}