using AutoMapper;
using CarRental.DAL.Models;
using CarRental.Web.Models;

namespace CarRental.Web.MapperProfiles;

public class RentalProfile : Profile
{
    public RentalProfile()
    {
        CreateMap<Rental, RentalViewModel>().ReverseMap();
    }
}
