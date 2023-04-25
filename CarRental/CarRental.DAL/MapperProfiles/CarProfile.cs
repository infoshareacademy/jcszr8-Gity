using AutoMapper;
using CarRental.Common.Enums;
using CarRental.DAL.Entities;
using CarRental.DAL.HelperModels;
using System.Diagnostics;
using System.Drawing;

namespace CarRental.DAL.MapperProfiles;
public class CarProfile : Profile
{
    public CarProfile()
    {
        CreateMap<List<string>, string>()
            .ConvertUsing(new ListToStringConverter());

        CreateMap<CarFromJson, Car>()
            .ConvertUsing<CarFromJsonToCarConverter>();
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


public class ListToStringConverter : ITypeConverter<List<string>, string>
{
    public string Convert(List<string> source, string destination, ResolutionContext context)
    {
        return string.Join(",", source);
    }
}

public class CarFromJsonToCarConverter : ITypeConverter<CarFromJson, Car>
{
    public Car Convert(CarFromJson source, Car destination, ResolutionContext context)
    {
        Car car;
        try
        {
            car = new Car
            {
                Addons = string.Join(", ", source.Addons),

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