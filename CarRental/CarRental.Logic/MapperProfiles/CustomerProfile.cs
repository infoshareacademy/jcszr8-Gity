using AutoMapper;
using CarRental.DAL.Entities;
using CarRental.Logic.Models;

namespace CarRental.Logic.MapperProfiles;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<CustomerViewModel, Customer>(MemberList.Source);

        CreateMap<Customer, CustomerViewModel>(MemberList.Destination);
    }
}
