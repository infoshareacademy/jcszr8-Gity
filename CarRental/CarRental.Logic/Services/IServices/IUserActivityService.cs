using CarRental.Logic.Models;

namespace CarRental.Logic.Services.IServices;
public interface IUserActivityService
{
    Task OnDetailsButtonClicked(CarViewModel visitedCar);
}
