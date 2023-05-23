using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
