using AutoMapper;
using CarRental.DAL.Entities;
using CarRental.DAL.HelperModels;

namespace CarRental.DAL.HelperMapperProfiles;
public class RentalJsonProfile : Profile
{
    public RentalJsonProfile()
    {
        CreateMap<RentalJson, Rental>()
            .ReverseMap();
    }
}
