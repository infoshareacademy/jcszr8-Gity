using AutoMapper;
using CarRental.DAL.Entities;
using CarRental.Logic.Models;

namespace CarRental.Logic.MapperProfiles;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<CustomerViewModel, Customer>();

        CreateMap<Customer, CustomerViewModel>();
        //.ForMember(c => c.GenderTest, opt => opt.Ignore())
        //.ForSourceMember(c => c.GenderTest, opt => opt.Ignore());
    }
}
