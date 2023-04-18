using AutoMapper;
using CarRental.DAL.Entities;
using CarRental.Logic.Models;

namespace CarRental.Logic.MapperProfiles;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<CustomerViewModel, Customer>().ReverseMap();

        //CreateMap<Customer, CustomerViewModel>();

            //.ForAllMembers(op => op.Condition(x => x is not null));
        //.ForMember(c => c.GenderTest, opt => opt.Ignore())
        //.ForSourceMember(c => c.GenderTest, opt => opt.Ignore());
    }
}
