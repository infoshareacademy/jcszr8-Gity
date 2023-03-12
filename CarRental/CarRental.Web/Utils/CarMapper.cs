using CarRental.DAL.Models;
using CarRental.Web.Models;

namespace CarRental.Web;

public class CarMapper
{
    public List<CarListModel> Map(IEnumerable<Car> cars)
    {
        List<CarListModel> carListModels = new();
        foreach (var car in cars)
        {
            carListModels.Add(
                new CarListModel
                {
                    Id = car.Id,
                    CarModel = car.CarModel,
                    Make = car.Make
                });
        }
        return carListModels;
    }
}
