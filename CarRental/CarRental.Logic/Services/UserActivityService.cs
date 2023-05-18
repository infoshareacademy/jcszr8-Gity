using System.Text;
using AutoMapper;
using CarRental.DAL.Entities;
using CarRental.Logic.Models;
using CarRental.Logic.Services.IServices;

namespace CarRental.Logic.Services;
public class UserActivityService : IUserActivityService
{
    private readonly HttpClient httpClient;
    private readonly IMapper _mapper;

    public UserActivityService(IMapper mapper)
    {
        httpClient = new HttpClient();
        _mapper = mapper;
    }

    public async Task PostUserActivityAsync(VisitedCarDTO visitedCarDto,string apiEndpoint)
    {
        _mapper.Map<VisitedCar>(visitedCarDto);
        var requestData = visitedCarDto;
        var json = Newtonsoft.Json.JsonConvert.SerializeObject(requestData);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        await httpClient.PostAsync(apiEndpoint, content);
    }

    public async Task OnDetailsButtonClicked(CarViewModel visitedCar)
    {
        var apiEndpoint = "https://localhost:7225/VisitedCar"; ;
        var carToPost = new VisitedCarDTO
        {
            UserId = 12,
            CarId = visitedCar.Id,
            DateWhenClicked = DateTime.Now,
            Make = visitedCar.Make,
            Model = visitedCar.CarModelProp,
            Year = visitedCar.Year,
            LicencePlate = visitedCar.LicencePlateNumber
        };
        await PostUserActivityAsync(carToPost, apiEndpoint);
    }
}
