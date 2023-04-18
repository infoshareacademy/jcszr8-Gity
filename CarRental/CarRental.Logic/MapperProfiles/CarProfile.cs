using AutoMapper;
using CarRental.DAL.Entities;
using CarRental.Logic.Models;
using CommonLibrary.Enums;

namespace CarRental.Logic.MapperProfiles;

public class CarProfile : Profile
{
    public CarProfile()
    {
        //new MapperConfiguration(cfg =>
        //{
        //    //cfg.AddMaps(new[] { "CarRental.Logic" });
        //    cfg.ClearPrefixes();
        //});

        //CreateMap<Car, CarViewModel>();
        //CreateMap<CarViewModel, Car>();
        //var configuration = new MapperConfiguration(cfg => cfg.CreateMap<Car, CarViewModel>());

        //CreateMap<string, List<string>>().ConvertUsing<StringToListConverter>();
        //CreateMap<Car, CarViewModel>()
        //    .ForMember(dest => dest.Addons,
        //         opt => opt.MapFrom(src => src.Addons.Split(";").ToList()));

        CreateMap<Car, CarViewModel>().ConvertUsing<CarToCarViewModelConverter>();

        CreateMap<CarViewModel, Car>().ConvertUsing<CarViewModelToCarConverter>();

        //    .IgnoreAllUnmapped();

        var configuration = new MapperConfiguration(cfg =>
        {
            //cfg.CreateMap<string, List<string>>().ConvertUsing(s => GetAddonsAsList(s));
            cfg.CreateMap<Car, CarViewModel>().ConvertUsing<CarToCarViewModelConverter>();
            cfg.CreateMap<CarViewModel, Car>().ConvertUsing<CarViewModelToCarConverter>();
        });
        configuration.AssertConfigurationIsValid();

        //.ForMember(dest => dest.Addons, opt => opt.MapFrom(src => string.Join(";", src.Addons)));
        //.ForMember(dest => dest.Addons, opt => opt.MapFrom(src => src.Addons.Split(";", StringSplitOptions.None).ToList()))
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
        List<string> addons = new();
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
            Addons = addons,

            Make = "Toyota", //source.Make,
            CarModelProp = "Corolla", // source.CarModelProp,
            Year = 2020, //source.Year,
            Color = "red", //source.Color,
            Transmission = TransmissionType.Manual, // source.Transmission,
            LicencePlateNumber = "GD1234", //source.LicencePlateNumber,
            Kilometrage = 1000, // source.Kilometrage,
            PowerInKiloWats = 0, // source.PowerInKiloWats,
            EngineType = EngineType.Electric, //source.EngineType,
            Displacement = string.Empty, // source.Displacement,
            Doors = 5, //source.Doors,
            SeatsNo = 1, //source.SeatsNo,
            Airbags = 1, //source.Airbags,
            FuelConsumption = string.Empty, // source.FuelConsumption,
            Price = 0, //source.Price,
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
