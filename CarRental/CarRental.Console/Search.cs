using CarRental.ConsoleUI.Utils;
using CarRental.DAL;
using CarRental.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.ConsoleUI
{
    public class Search
    {
        public static void CarByMake()
        {
            while (true)
            {
                Console.WriteLine("Podaj nazwe auta:");
                List<Car> cars = new List<Car>();
                var make = Console.ReadLine();
                if (string.IsNullOrEmpty(make))
                {
                    cars = CarRentalData.Cars;
                }
                else
                {
                    cars = CarRentalData.Cars.Where(c => c.Make?.ToLower() == make.ToLower()).ToList();
                }

                Print(cars);
                ConsoleKeyInfo read = Console.ReadKey();
                if (read.Key == ConsoleKey.Escape) break;
            }
        }
        public static void PrintDetails(List<Car> cars)
        {
            if (cars is null || cars.Count == 0)
            {
                Console.WriteLine("Brak samochodów o  tych parametrach");
            }
            else
            {
                foreach (var car in cars)
                {
                    Console.WriteLine(car.GetDetails());
                }
            }
        }
        public static void Print(List<Car> cars)
        {
            if (cars is null || cars.Count == 0)
            {
                Console.WriteLine("Brak samochodów o  tych parametrach");
            }
            else
            {
                foreach (var car in cars)
                {
                    Console.WriteLine(car.ToString());
                }
            }
        }
        //Zastępstwo za przyszłe funkcje
        public static void PlaceHolder()
        {
            Console.WriteLine("PlaceHolder");
            Console.ReadKey();
        }
    }
}
