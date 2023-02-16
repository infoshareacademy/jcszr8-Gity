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
    public class Search
    {

        public static List<Rental> CarByMake(string make)
        {
            List<Rental> cars = new List<Rental>();
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

        public static List<Rental> CarByName(string name)
        {
            List<Rental> cars = new List<Rental>();
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

        public static List<Rental> CarByYear(string read)
        {
            int year;
            bool makes = int.TryParse(read, out year);
            List<Rental> cars = new List<Rental>();
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

        public static List<Rental> CarByAddons(string addon)
        {
            List<Rental> cars = new List<Rental>();
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
    }
}
