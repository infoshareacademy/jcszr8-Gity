using AutoMapper;
using CarRental.DAL.Entities;
using CarRental.Logic.Models;

namespace CarRental.Web.MapperProfiles;

public class RentalProfile : Profile
{
    public RentalProfile()
    {
        CreateMap<RentalModel, Rental>().ReverseMap();
    }
}
