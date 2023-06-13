using AutoMapper;
using CarRental.DAL.Entities;
using CarRental.Logic.Models;

namespace CarRental.Logic.MapperProfiles;
public class VisitedCarProfile : Profile
{
    public VisitedCarProfile()
    {
        CreateMap<VisitedCar, VisitedCarViewModel>()
            .ReverseMap();
    }
}
