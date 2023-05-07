using AutoMapper;
using CarRental.DAL.Entities;
using CarRental.Logic.Models;

namespace CarRental.Logic.MapperProfiles;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<CustomerViewModel, Customer>()
            .ReverseMap();

        //CreateMap<CustomerFromJson, Customer>()
        //    .ReverseMap();
    }
}
