using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CarRental.DAL.Entities;
using CarRental.DAL.Repositories;
using CarRental.Logic.Models;
using CarRental.Logic.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Logic.Services;
public class ReportApiService : IReportApiService
{
    private readonly IMapper _mapper;
    private readonly IRepository<VisitedCar> _visitedCarRepository;
    private readonly IRepository<LastLoggedReport> _lastLoggedReportRepository;

    public ReportApiService(IMapper mapper, IRepository<VisitedCar> visitedCarRepository, IRepository<LastLoggedReport> lastLoggedReportRepository)
    {
        _mapper = mapper;
        _visitedCarRepository = visitedCarRepository;
        _lastLoggedReportRepository = lastLoggedReportRepository;
    }

    public async Task Create(VisitedCarViewModel model)
    {
        var visitedCar = _mapper.Map<VisitedCar>(model);
        _visitedCarRepository.Insert(visitedCar);
    }

    public async Task<IEnumerable<VisitedCarViewModel>> GetByIdAndDateAsync(int id, DateTime from, DateTime to)
    {
        var lista =  _visitedCarRepository.GetAll().Where(x =>
            x.UserId == id && x.DateWhenClicked >= from && x.DateWhenClicked <= to).ToList();

        return _mapper.Map<IEnumerable<VisitedCarViewModel>>(lista);
    }
}
