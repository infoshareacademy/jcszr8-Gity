using System.Text;
using AutoMapper;
using CarRental.DAL.Entities;
using CarRental.DAL.Repositories;
using CarRental.Logic.Models;
using CarRental.Logic.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace CarRental.Logic.Services;
public class ReportService : IReportService // ReportService
{
    private readonly HttpClient httpClient;
    private readonly IMapper _mapper;
    private readonly UserManager<Customer> _userManager;
    private readonly IRepository<VisitedCar> _visitedCarRepository;
    private readonly IRepository<LastLoggedReport> _lastLoggedReportRepository;
    public ReportService(IMapper mapper, UserManager<Customer> userManager, IRepository<VisitedCar> visitedCarRepository, IRepository<LastLoggedReport> lastLoggedReportRepository)
    {
        httpClient = new HttpClient();
        _mapper = mapper;
        _userManager = userManager;
        _visitedCarRepository = visitedCarRepository;
        _lastLoggedReportRepository = lastLoggedReportRepository;
    }

    private async Task<HttpResponseMessage> PostUserActivityAsync(object reportModel, string apiEndpoint)
    {
        var json = Newtonsoft.Json.JsonConvert.SerializeObject(reportModel);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        return await httpClient.PostAsync(apiEndpoint, content);
    }

    public async Task ReportCarVisitAsync(CarViewModel visitedCar, string userId)
    {
        int userIdToInt;
        userIdToInt = int.Parse(userId);
        var apiEndpoint = "https://localhost:7225/VisitedCar";
        var carToPost = new VisitedCarViewModel
        {
            UserId = userIdToInt,
            CarId = visitedCar.Id,
            DateWhenClicked = DateTime.Now,
            Make = visitedCar.Make,
            Model = visitedCar.CarModelProp,
            Year = visitedCar.Year,
            LicencePlate = visitedCar.LicencePlateNumber
        };

        _mapper.Map<VisitedCar>(carToPost);
        var response = await PostUserActivityAsync(carToPost, apiEndpoint);
        if (!response.IsSuccessStatusCode)
        {
            // Task logowanie zdarzeń aplikacji (dodać log.Error)
        }
    }

    public async Task ReportUserLoginAsync(string email)
    {
        var userId = await GetUserIdAsync(email);
        var apiEndpoint = "https://localhost:7225/Report";
        var userToPost = new LastLoggedReportDTO
        {
            UserId = userId,
            LastLogged = DateTime.Now,
            LoginCount = +1
        };

        _mapper.Map<LastLoggedReport>(userToPost);
        var response = await PostUserActivityAsync(userToPost, apiEndpoint);
        if (!response.IsSuccessStatusCode)
        {
            // Task logowanie zdarzeń aplikacji (dodać log.Error)
        }
    }
    private async Task<int> GetUserIdAsync(string email)
    {
        var user = _userManager.Users.FirstOrDefault(c => c.Email == email);
        var userId = user.Id;
        return userId;
    }

    //public async Task<IEnumerable<VisitedCarViewModel>> GenerateCarVisitReportAsync(int userId, DateTime from , DateTime to)
    //{
    //    var visitedCars = GetAll().Where(v => v.UserId == userId);
    //    visitedCars.Where(v => v.DateWhenClicked >= from && v.DateWhenClicked <= to);

    //    return _mapper.Map<IEnumerable<VisitedCarViewModel>>(visitedCars); ;
    //}

    //private IEnumerable<VisitedCarViewModel> GetAll()
    //{
    //    List<VisitedCar> visitedCars = _visitedCarRepository.GetAll();
    //    return _mapper.Map<IEnumerable<VisitedCarViewModel>>(visitedCars);
    //}

}
