using CarRental.DAL;
using CarRental.DAL.Models;
using CarRental.DAL.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Logic
{
    public class LogicSearch
    {

        public static List<Car> CarByMake(string make)
        {
            List<Car> cars = new List<Car>();
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

        public static List<Car> CarByName(string name)
        {
            List<Car> cars = new List<Car>();
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

        public static List<Car> CarByYear(string read)
        {
            int year;
            bool makes = int.TryParse(read, out year);
            List<Car> cars = new List<Car>();
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

        public static List<Car> CarByAddons(string addon)
        {
            List<Car> cars = new List<Car>();
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
        public static string Print(List<Car> cars)
        {
            StringBuilder sb = new();
            sb.Append(String.Format("\n{0,4}.| {1,-20}| {2,-25}| {3,-10}| {4,-20}\n", "Id", "Make", "Model", "License plate", "Addons"));
            sb.Append(new String('-', sb.Length));
            sb.Append('\n');
            foreach (var car in cars)
            {
                sb.Append($"{car.Id,4}.| {car.Make,-20}| {car.CarModel,-25}| {car.LicencePlateNumber,-20}| {car.GetAddonsToString(),10}{Environment.NewLine}");
            }
            return sb.ToString();
        }
    }
}
