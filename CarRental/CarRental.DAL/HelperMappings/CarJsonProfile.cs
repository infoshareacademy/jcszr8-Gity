using AutoMapper;
using CarRental.DAL.Entities;

namespace CarRental.DAL.HelperMappings;
public class CarJsonProfile : Profile
{
    public CarJsonProfile()
    {
        CreateMap<CarJsonProfile, Car>()
            .ReverseMap();
    }
}
