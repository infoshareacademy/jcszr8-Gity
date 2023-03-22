using CarRental.DAL;
using CarRental.DAL.Models;
using System.Text;

namespace CarRental.Logic;

public class LogicSearch
{

    public static List<CarModel> CarByMake(string make)
    {
        List<CarModel> cars = new List<CarModel>();
        if (string.IsNullOrEmpty(make))
        {
            cars = CarRentalData.Cars;
        }
        else
        {
            cars = CarRentalData.Cars.Where(c => c.Make?.ToLower() == make.ToLower() ||
                                                 c.CarModel?.ToLower() == make.ToLower()).ToList();
        }
        return cars;
    }

    public static List<CarModel> CarByName(string name)
    {
        List<CarModel> cars = new List<CarModel>();
        if (string.IsNullOrEmpty(name))
        {
            cars = CarRentalData.Cars;
        }
        else
        {

            cars = CarRentalData.Cars.Where(c => c.Make.Contains(name, StringComparison.CurrentCultureIgnoreCase)
                || c.CarModel.Contains(name, StringComparison.CurrentCultureIgnoreCase)
            ).ToList();
        }
        return cars;
    }

    public static List<CarModel> CarByYear(string read)
    {
        int year;
        bool makes = int.TryParse(read, out year);
        List<CarModel> cars = new List<CarModel>();
        if (read == null)
        {
            cars = CarRentalData.Cars;
        }
        else
        {
            cars = CarRentalData.Cars.Where(c => c.Year == year).ToList();
        }
        return cars;
    }

    public static List<CarModel> CarByAddons(string addon)
    {
        List<CarModel> cars = new List<CarModel>();
        if (string.IsNullOrEmpty(addon))
        {
            cars = CarRentalData.Cars;
        }
        else
        {
            foreach (var car in CarRentalData.Cars)
            {
                foreach (var item in car.Addons)
                {
                    if (item.Contains(addon))
                    {
                        cars.Add(car);
                        break;
                    }
                }
            }
            //cars = CarRentalData.Cars.Where(c => c.Addons.Where(x => x.Contains(addon)).FirstOrDefault()
        }
        return cars;
    }

    public static string Print(List<CarModel> cars)
    {
        StringBuilder sb = new();
        sb.Append(String.Format("\n{0,4}.| {1,-20}| {2,-25}| {3,-20}| {4,-20}\n", "Id", "Make", "Model", "License plate", "Addons"));
        sb.Append(new String('-', sb.Length));
        sb.Append('\n');
        foreach (var car in cars)
        {
            sb.Append($"{car.Id,4}.| {car.Make,-20}| {car.CarModel,-25}| {car.LicencePlateNumber,-20}| {car.GetAddonsToString(),-20}{Environment.NewLine}");
        }
        return sb.ToString();
    }
}
