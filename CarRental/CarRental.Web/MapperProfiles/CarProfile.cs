using AutoMapper;
using CarRental.DAL.Entities;
using CarRental.Logic.Models;
using CarRental.Logic.Test;

namespace CarRental.Web.MapperProfiles;

public class CarProfile : Profile
{
    public CarProfile()
    {
        CreateMap<CarModel, Car>()
            .ForMember(dest => dest.Make, opt => opt.MapFrom(src => src.Make))
            .ForMember(dest => dest.CarModelProp, opt => opt.MapFrom(src => src.CarModelProp))
            .ForMember(dest => dest.LicencePlateNumber, opt => opt.MapFrom(src => src.LicencePlateNumber))
            .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Year))
            .ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.Color))
            .ReverseMap();


        CreateMap<CarModel, Car>()
            .ForMember(dest => dest.Addons, opt => opt.MapFrom<AddonsResolver>());

        CreateMap<Car, CarModel>()
            .ForMember(dest => dest.Addons, opt => opt.MapFrom(src => "addon"));
            //.ForMember(dest => dest.Addons, opt => opt.MapFrom(src => src.Addons.Split(";").ToList()));
    }
}
