using AutoMapper;
using CarRental.DAL.Entities;
using CarRental.DAL.HelperModels;

namespace CarRental.DAL.MapperProfiles;
public class CarProfile : Profile
{
    public CarProfile()
    {
        CreateMap<CarFromJson, Car>()
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
}
