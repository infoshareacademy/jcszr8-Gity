using AutoMapper;
using CarRental.DAL.Entities;
using CarRental.Logic.Models;
using CommonLibrary.Enums;

namespace CarRental.Logic.MapperProfiles;

public class CarProfile : Profile
{
    public CarProfile()
    {

        //CreateMap<Car, CarViewModel>().ConvertUsing<CarToCarViewModelConverter>();
        //CreateMap<CarViewModel, Car>().ConvertUsing<CarViewModelToCarConverter>();


        //.IgnoreAllUnmapped();

        //.ForMember(dest => dest.Addons, opt => opt.MapFrom(src => string.Join(";", src.Addons)));
        //.ForMember(dest => dest.Addons, opt => opt.MapFrom(src => src.Addons.Split(";", StringSplitOptions.None).ToList()))

        // Use detailed way to map properties
        CreateMap<Car, CarViewModel>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Make, opt => opt.MapFrom(src => src.Make))
            .ForMember(dest => dest.CarModelProp, opt => opt.MapFrom(src => src.CarModelProp))
            .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Year))
            .ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.Color))
            .ForMember(dest => dest.Transmission, opt => opt.MapFrom(src => src.Transmission))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
            .ForMember(dest => dest.LicencePlateNumber, opt => opt.MapFrom(src => src.LicencePlateNumber))
            .ForMember(dest => dest.Kilometrage, opt => opt.MapFrom(src => src.Kilometrage))
            .ForMember(dest => dest.PowerInKiloWats, opt => opt.MapFrom(src => src.PowerInKiloWats))
            .ForMember(dest => dest.EngineType, opt => opt.MapFrom(src => src.EngineType))
            .ForMember(dest => dest.Displacement, opt => opt.MapFrom(src => src.Displacement))
            .ForMember(dest => dest.Doors, opt => opt.MapFrom(src => src.Doors))
            .ForMember(dest => dest.SeatsNo, opt => opt.MapFrom(src => src.SeatsNo))
            .ForMember(dest => dest.Airbags, opt => opt.MapFrom(src => src.Airbags))
            .ForMember(dest => dest.FuelConsumption, opt => opt.MapFrom(src => src.FuelConsumption))
            .ForMember(dest => dest.Addons, opt => opt.MapFrom(src => new List<string>()));  // TODO
        //.ForMember(dest => dest.Addons, opt => opt.MapFrom(src => src.Addons!.Split(";", StringSplitOptions.None).ToList()));


        CreateMap<CarViewModel, Car>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Make, opt => opt.MapFrom(src => src.Make))
            .ForMember(dest => dest.CarModelProp, opt => opt.MapFrom(src => src.CarModelProp))
            .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Year))
            .ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.Color))
            .ForMember(dest => dest.Transmission, opt => opt.MapFrom(src => src.Transmission))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
            .ForMember(dest => dest.LicencePlateNumber, opt => opt.MapFrom(src => src.LicencePlateNumber))
            .ForMember(dest => dest.Kilometrage, opt => opt.MapFrom(src => src.Kilometrage))
            .ForMember(dest => dest.PowerInKiloWats, opt => opt.MapFrom(src => src.PowerInKiloWats))
            .ForMember(dest => dest.EngineType, opt => opt.MapFrom(src => src.EngineType))
            .ForMember(dest => dest.Displacement, opt => opt.MapFrom(src => src.Displacement))
            .ForMember(dest => dest.Doors, opt => opt.MapFrom(src => src.Doors))
            .ForMember(dest => dest.SeatsNo, opt => opt.MapFrom(src => src.SeatsNo))
            .ForMember(dest => dest.Airbags, opt => opt.MapFrom(src => src.Airbags))
            .ForMember(dest => dest.FuelConsumption, opt => opt.MapFrom(src => src.FuelConsumption))
            .ForMember(dest => dest.Addons, opt => opt.MapFrom(src => string.Join(";", src.Addons)));

    }

    private List<string> GetAddonsAsList(string model)
    {
        if (string.IsNullOrEmpty(model))
        {
            return new List<string>();
        }
        return model.Split(";").ToList();
    }
}

public class StringToListConverter : ITypeConverter<string, List<string>>
{
    public List<string> Convert(string source, List<string> destination, ResolutionContext context)
    {
        return source?.Split(',').ToList();
    }
}

public class CarToCarViewModelConverter : ITypeConverter<Car, CarViewModel>
{
    public CarViewModel Convert(Car source, CarViewModel destination, ResolutionContext context)
    {
        List<string> addons;
        try
        {
            if (string.IsNullOrEmpty(source?.Addons))
            {
                addons = new();
            }
            else
            {
                addons = new(); // source?.Addons?.Split(";").ToList();
                addons ??= new();
            }
        }
        catch (Exception)
        {
            addons = new();
        }
        var carViewModel = new CarViewModel
        {
            Id = source.Id,
            Addons = addons,

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
        return carViewModel;
    }
}

public class CarViewModelToCarConverter : ITypeConverter<CarViewModel, Car>
{
    public Car Convert(CarViewModel source, Car destination, ResolutionContext context)
    {
        var addons = string.Join(";", source.Addons);
        var car = new Car
        {
            Id = source.Id,
            Addons = addons,

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
        return car;
    }
}
public static class MappingExpressionExtensions
{
    public static IMappingExpression<TSource, TDest> IgnoreAllUnmapped<TSource, TDest>(this IMappingExpression<TSource, TDest> expression)
    {
        expression.ForAllMembers(opt => opt.Ignore());
        return expression;
    }
}

public class AddonsResolver : IValueResolver<CarViewModel, Car, string>
{
    public string Resolve(CarViewModel source, Car destination, string destMember, ResolutionContext context)
    {
        return string.Join(",", source.Addons);
    }
}
