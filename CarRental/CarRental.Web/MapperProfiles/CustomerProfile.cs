using AutoMapper;
using CarRental.DAL.Entities;
using CarRental.Logic.Models;

namespace CarRental.Web.MapperProfiles;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<CustomerDto, Customer>();

        CreateMap<Customer, CustomerDto>();
            //.ForMember(c => c.GenderTest, opt => opt.Ignore())
            //.ForSourceMember(c => c.GenderTest, opt => opt.Ignore());
    }
}
