using AutoMapper;
using CarRental.DAL.Entities;
using CarRental.DAL.Repositories;
using CarRental.Logic.Models;
using CarRental.Logic.Services.IServices;

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

    public async Task CreateVisitedCarAsync(VisitedCarViewModel model)
    {
        var visitedCar = _mapper.Map<VisitedCar>(model);
        _visitedCarRepository.Insert(visitedCar);
    }

    public async Task CreateLastLoggedAsync(LastLoggedReportDTO model)
    {
        var lastLogged = _mapper.Map<LastLoggedReport>(model);
        _lastLoggedReportRepository.Insert(lastLogged);
    }

    public async Task<IEnumerable<VisitedCarViewModel>> GetVisitedCarByIdAndDateAsync(int id, DateTime from, DateTime to)
    {
        var lista = _visitedCarRepository.GetAll().Where(x =>
            x.UserId == id && x.DateWhenClicked >= from && x.DateWhenClicked <= to).ToList();

        return _mapper.Map<IEnumerable<VisitedCarViewModel>>(lista);
    }

    public async Task<IEnumerable<LastLoggedReportDTO>> GetLastLoggerdByIdAndDateAsync(int id, DateTime from, DateTime to)
    {
        var lista = _lastLoggedReportRepository.GetAll().Where(x =>
            x.UserId == id && x.LastLogged >= from && x.LastLogged <= to).ToList();

        return _mapper.Map<IEnumerable<LastLoggedReportDTO>>(lista);
    }
}
