using CarRental.DAL.Models;
using CarRental.Web.Models;

namespace CarRental.Web;

public class CarMapper
{
    public List<CarViewModel> Map(IEnumerable<Car> cars)
    {
        List<CarViewModel> carListModels = new();
        foreach (var car in cars)
        {
            carListModels.Add(
                new CarViewModel
                {
                    Id = car.Id,
                    CarModel = car.CarModel,
                    Make = car.Make
                });
        }
        return carListModels;
    }
}
