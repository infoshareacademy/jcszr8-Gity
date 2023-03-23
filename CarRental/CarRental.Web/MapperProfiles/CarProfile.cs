using AutoMapper;
using CarRental.DAL.Models;
using CarRental.Logic.Test;
using CarRental.Web.Models;

namespace CarRental.Web.MapperProfiles;

public class CarProfile : Profile
{
    public CarProfile()
    {
        CreateMap<CarModel, Car>()
            .ForMember(dto => dto.Addons, opt => opt.MapFrom<AddonsResolver>());
    }
}

