using System.Text;
using CarRental.Web.Models;

namespace CarRental.Web.ActivityLogger;
public class ActivityLogger
{
    private readonly HttpClient httpClient;
    private readonly string apiEndpoint;

    public ActivityLogger(string apiEndpoint)
    {
        httpClient = new HttpClient();
        this.apiEndpoint = apiEndpoint;
    }

    public async Task LogActivityAsync(VisitedCarDTO visitedCarDto)
    {
        var requestData = visitedCarDto;
        var json = Newtonsoft.Json.JsonConvert.SerializeObject(requestData);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        await httpClient.PostAsync(apiEndpoint, content);
    }
}
