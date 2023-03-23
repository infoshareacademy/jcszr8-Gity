using CarRental.Logic.Models;

namespace CarRental.Web;

public class CarMapper
{
    public List<CarModel> Map(IEnumerable<CarModel> cars)
    {
        List<CarModel> carListModels = new();
        foreach (var car in cars)
        {
            carListModels.Add(
                new CarModel
                {
                    Id = car.Id,
                    CarModelProp = car.CarModelProp,
                    Make = car.Make
                });
        }
        return carListModels;
    }
}
