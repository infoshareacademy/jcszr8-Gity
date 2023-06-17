using AutoMapper;
using CarRental.DAL.Entities;
using CarRental.DAL.Repositories;
using CarRental.Logic.Models;

namespace CarRental.Logic.ServicesApi;
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

    public async Task<IEnumerable<VisitedCarViewModel>> GetDailyVisitedCar()
    {
        var visitedCars = _visitedCarRepository.GetAll().Where(x => x.DateWhenClicked >= DateTime.Today && x.DateWhenClicked <= DateTime.Today.AddDays(1));
        return _mapper.Map<IEnumerable<VisitedCarViewModel>>(visitedCars);
    }

    public async Task<IEnumerable<LastLoggedReportDTO>> GetDailyLastLogged()
    {
        var lastLogged = _lastLoggedReportRepository.GetAll().Where(x => x.Created >= DateTime.Today && x.Created <= DateTime.Today.AddDays(1));
        return _mapper.Map<IEnumerable<LastLoggedReportDTO>>(lastLogged);
    }
}
