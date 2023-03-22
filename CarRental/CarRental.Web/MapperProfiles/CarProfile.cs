using AutoMapper;
using CarRental.DAL.Models;
using CarRental.Web.Models;

namespace CarRental.Web.MapperProfiles;

public class CarProfile : Profile
{
    public CarProfile()
    {
        CreateMap<Car, CarViewModel>().ReverseMap();
    }
}
