using CarRental.Logic.Models;

namespace CarRental.Logic.Services.IServices;
public interface IUserActivityService
{
    Task PostUserActivityAsync(VisitedCarDTO visitedCarDto,string apiEndpoint);
    Task OnDetailsButtonClicked(CarViewModel visitedCar);
}
