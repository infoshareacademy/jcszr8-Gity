using AutoMapper;
using CarRental.DAL.Entities;
using CarRental.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Logic.MapperProfiles;
public class CarTempProfile : Profile
{
    public CarTempProfile()
    {
        CreateMap<CarTemp, CarTempViewModel>()
            .ForMember(dest => dest.Addons,
                           opt => opt.MapFrom(src => src.Addons.Split(";").ToList()));
    }
}
