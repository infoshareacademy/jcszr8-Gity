using AutoMapper;
using CarRental.DAL.Entities;
using CarRental.DAL.HelperModels;

namespace CarRental.DAL.HelperMapperProfiles;
public class CustomerJsonProfile : Profile
{
    public CustomerJsonProfile()
    {
        CreateMap<CustomerJson, Customer>()
            .ReverseMap();
    }
}
