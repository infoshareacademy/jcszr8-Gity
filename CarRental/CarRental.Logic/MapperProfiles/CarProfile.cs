using AutoMapper;
using CarRental.DAL.Entities;
using CarRental.Logic.Models;

namespace CarRental.Logic.MapperProfiles;

public class CarProfile : Profile
{
    public CarProfile()
    {
        CreateMap<Car, CarViewModel>()
            .ReverseMap();
    }
}
