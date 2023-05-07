using AutoMapper;
using CarRental.DAL.Entities;
using CarRental.DAL.HelperModels;

namespace CarRental.DAL.HelperMappings;
public class CustomerJsonProfile : Profile
{
    public CustomerJsonProfile()
    {
        CreateMap<CustomerJson, Customer>()
            .ReverseMap();
    }
}
