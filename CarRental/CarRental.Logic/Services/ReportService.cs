using System.Text;
using AutoMapper;
using CarRental.DAL.Entities;
using CarRental.DAL.Repositories;
using CarRental.Logic.Models;
using CarRental.Logic.Services.IServices;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using static System.Net.WebRequestMethods;

namespace CarRental.Logic.Services;
public class ReportService : IReportService // ReportService
{
    private readonly HttpClient _httpClient;
    private readonly IMapper _mapper;
    private readonly UserManager<Customer> _userManager;
    private readonly IRepository<VisitedCar> _visitedCarRepository;
    private readonly IRepository<LastLoggedReport> _lastLoggedReportRepository;
    public ReportService(IMapper mapper, UserManager<Customer> userManager, IRepository<VisitedCar> visitedCarRepository, IRepository<LastLoggedReport> lastLoggedReportRepository)
    {
        _httpClient = new HttpClient();
        _mapper = mapper;
        _userManager = userManager;
        _visitedCarRepository = visitedCarRepository;
        _lastLoggedReportRepository = lastLoggedReportRepository;
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
        var apiEndpoint = "https://localhost:7225/LastLogged";
        var userToPost = new LastLoggedReportDTO
        {
            UserId = userId,
            LastLogged = DateTime.Now,
        };

        _mapper.Map<LastLoggedReport>(userToPost);
        var response = await PostUserActivityAsync(userToPost, apiEndpoint);
        if (!response.IsSuccessStatusCode)
        {
            // Task logowanie zdarzeń aplikacji (dodać log.Error)
        }
    }

    public async Task<IEnumerable<object>> GetReportsAsync(int userId, DateTime from, DateTime to, string reportType)
    {
        var apiEndpoint = reportType == "visitedCars"
            ? $"https://localhost:7225/VisitedCar/{userId}/{from:yyyy-MM-dd hh:mm:ss}/{to:yyyy-MM-dd hh:mm:ss}"
            : $"https://localhost:7225/LastLogged/{userId}/{from:yyyy-MM-dd hh:mm:ss}/{to.AddSeconds(1):yyyy-MM-dd hh:mm:ss}";
        IEnumerable<object> visitedCars = await GetFromApiAsync(apiEndpoint, reportType);
        return visitedCars;
    }

    private async Task<HttpResponseMessage> PostUserActivityAsync(object reportModel, string apiEndpoint)
    {
        var json = Newtonsoft.Json.JsonConvert.SerializeObject(reportModel);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        return await _httpClient.PostAsync(apiEndpoint, content);
    }

    public async Task<GeneratedReportViewModel> GetDailyReport()
    {
        GeneratedReportViewModel combinetReport = new GeneratedReportViewModel();
        var visitedCarsList = new List<VisitedCarViewModel>();
        var lastLoggedList = new List<LastLoggedReportDTO>();
        using (var httpClient = new HttpClient())
        {
            var getVisitedCars = await httpClient.GetAsync($"https://localhost:7225/VisitedCar/");
            var getLastLogged = await httpClient.GetAsync($"https://localhost:7225/LastLogged/");


            if (getVisitedCars.IsSuccessStatusCode && getLastLogged.IsSuccessStatusCode)
            {
                var responseCarData = await getVisitedCars.Content.ReadAsStringAsync();
                visitedCarsList = JsonConvert.DeserializeObject<IEnumerable<VisitedCarViewModel>>(responseCarData).ToList();

                var responseLastLoggedData = await getLastLogged.Content.ReadAsStringAsync();
                lastLoggedList = JsonConvert.DeserializeObject<IEnumerable<LastLoggedReportDTO>>(responseLastLoggedData).ToList();

                combinetReport.LastLoggedReports = lastLoggedList;
                combinetReport.VisitedCars = visitedCarsList;
                return combinetReport;
            }

            return null;
        }

    }

    private async Task<IEnumerable<object>> GetFromApiAsync(string apiEndpoint, string reportType)
    {

        using (var httpClient = new HttpClient())
        {
            var response = await httpClient.GetAsync(apiEndpoint);

            if (response.IsSuccessStatusCode)
            {
                var responsData = await response.Content.ReadAsStringAsync();
                if (reportType == "visitedCars")
                {
                    var visitedCars = JsonConvert.DeserializeObject<IEnumerable<VisitedCarViewModel>>(responsData);
                    return visitedCars;
                }
                else if (reportType == "lastLogged")
                {
                    var lassLoggedReport = JsonConvert.DeserializeObject<IEnumerable<LastLoggedReportDTO>>(responsData);
                    return lassLoggedReport;
                }

            }
            return null;
        }
    }

    private async Task<int> GetUserIdAsync(string email)
    {
        var user = _userManager.Users.FirstOrDefault(c => c.Email == email);
        var userId = user.Id;
        return userId;
    }

}
