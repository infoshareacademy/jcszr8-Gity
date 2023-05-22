using System.Text;
using AutoMapper;
using CarRental.DAL.Entities;
using CarRental.Logic.Models;
using CarRental.Logic.Services.IServices;
using Microsoft.AspNetCore.Identity;

namespace CarRental.Logic.Services;
public class ReportService : IReportService // ReportService
{
    private readonly HttpClient httpClient;
    private readonly IMapper _mapper;
    private readonly UserManager<Customer> _userManager;
    public ReportService(IMapper mapper, UserManager<Customer> userManager)
    {
        httpClient = new HttpClient();
        _mapper = mapper;
        _userManager = userManager;
    }

    private async Task<HttpResponseMessage> PostUserActivityAsync(object reportModel,string apiEndpoint)//Podmienic na obiekt wywolywac wczesniej mappera
    {
        _mapper.Map<VisitedCar>(reportModel);
        var requestData = reportModel;
        var json = Newtonsoft.Json.JsonConvert.SerializeObject(requestData);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        return await httpClient.PostAsync(apiEndpoint, content);
    }

    public async Task ReportCarVisit(CarViewModel visitedCar,int userId)
    {
        var apiEndpoint = "https://localhost:7225/VisitedCar";
        var carToPost = new VisitedCarDTO
        {
            UserId = userId,
            CarId = visitedCar.Id,
            DateWhenClicked = DateTime.Now,
            Make = visitedCar.Make,
            Model = visitedCar.CarModelProp,
            Year = visitedCar.Year,
            LicencePlate = visitedCar.LicencePlateNumber
        };

        var response = await PostUserActivityAsync(carToPost, apiEndpoint);
        if (!response.IsSuccessStatusCode)
        {
            // Task logowanie zdarzeń aplikacji (dodać log.Error)
        }
    }
}
