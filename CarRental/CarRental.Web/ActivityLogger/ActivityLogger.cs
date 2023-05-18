using System.Text;
using AutoMapper;
using CarRental.DAL.Entities;
using CarRental.Logic.Models;
using CarRental.Web.Models;

namespace CarRental.Web.ActivityLogger;
public class ActivityLogger
{
    private readonly HttpClient httpClient;
    private readonly string apiEndpoint;
    private readonly IMapper _mapper;

    public ActivityLogger(string apiEndpoint,IMapper mapper)
    {
        httpClient = new HttpClient();
        this.apiEndpoint = apiEndpoint;
        _mapper = mapper;
    }

    public async Task LogActivityAsync(VisitedCarDTO visitedCarDto)
    {
        _mapper.Map<VisitedCar>(visitedCarDto);
        var requestData = visitedCarDto;
        var json = Newtonsoft.Json.JsonConvert.SerializeObject(requestData);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        await httpClient.PostAsync(apiEndpoint, content);
    }
}
