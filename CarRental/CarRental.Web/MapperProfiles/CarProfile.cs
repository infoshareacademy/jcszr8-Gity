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
            .ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.Color));
        //.ForMember(dest => dest.Addons, opt => opt.MapFrom(src => string.Join(";", src.Addons)));
        //.ForMember(dest => dest.Addons, opt => opt.Ignore())

        //CreateMap<CarModel, Car>()
        //    .ForMember(dest => dest.Addons, opt => opt.MapFrom(src => string.Join(";", src.Addons)));

        //CreateMap<CarModel, Car>()
        //    .ForMember(dest => dest.Addons, opt => opt.MapFrom<AddonsResolver>());

        CreateMap<Car, CarModel>()
            .ForMember(dest => dest.Make, opt => opt.MapFrom(src => src.Make))
            .ForMember(dest => dest.CarModelProp, opt => opt.MapFrom(src => src.CarModelProp))
            .ForMember(dest => dest.LicencePlateNumber, opt => opt.MapFrom(src => src.LicencePlateNumber))
            .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Year))
            .ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.Color));
           // .ForMember(dest => dest.Addons, opt => opt.MapFrom(src => src.Addons.Split(";", System.StringSplitOptions.None).ToList() ));
            //.ForMember(dest => dest.Addons, opt => opt.MapFrom(src => src.Addons.Split(";", System.StringSplitOptions.RemoveEmptyEntries).ToList() ));
    }
}
