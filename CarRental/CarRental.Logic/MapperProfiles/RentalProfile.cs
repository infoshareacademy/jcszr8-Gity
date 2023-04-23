using AutoMapper;
using CarRental.DAL.Entities;
using CarRental.Logic.Models;

namespace CarRental.Logic.MapperProfiles;

public class RentalProfile : Profile
{
    public RentalProfile()
    {
        CreateMap<RentalViewModel, Rental>().ReverseMap();
    }
}
