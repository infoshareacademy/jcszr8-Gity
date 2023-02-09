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
                                                     c.Model?.ToLower() == make.ToLower()).ToList();

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
        
        
    }
}
