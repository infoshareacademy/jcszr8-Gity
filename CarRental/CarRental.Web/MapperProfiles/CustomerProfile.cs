using AutoMapper;
using CarRental.DAL.Entities;
using CarRental.Logic.Models;

namespace CarRental.Web.MapperProfiles;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<CustomerModel, Customer>();

        CreateMap<Customer, CustomerModel>();
            //.ForMember(c => c.GenderTest, opt => opt.Ignore())
            //.ForSourceMember(c => c.GenderTest, opt => opt.Ignore());
    }
}
