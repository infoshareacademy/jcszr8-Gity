using AutoMapper;
using CarRental.DAL.Entities;
using CarRental.Logic.Models;

namespace CarRental.Logic.MapperProfiles;
public class LastLoggedProfile : Profile
{
    public LastLoggedProfile()
    {
        CreateMap<LastLoggedReport, LastLoggedReportDTO>()
            .ReverseMap();
    }
}
