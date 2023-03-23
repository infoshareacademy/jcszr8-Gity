using AutoMapper;
using CarRental.DAL.Models;
using CarRental.Web.Models;

namespace CarRental.Web.MapperProfiles;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<Customer, CustomerViewModel>().ReverseMap();
    }
}
