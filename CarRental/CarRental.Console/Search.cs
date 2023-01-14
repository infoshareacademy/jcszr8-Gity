using CarRental.DAL;
using CarRental.DAL.Models;

namespace CarRental.ConsoleUI;
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
<<<<<<< Updated upstream
    
    public static void CarByAddon()
=======
    public static void CarByAddons()
    {
        Console.WriteLine("Podaj jakie wyposażenie cie interesuje: ");
        List<Car> cars = new List<Car>();
        var addons = Console.ReadLine();
        if (string.IsNullOrEmpty(addons))
        {
            cars = CarRentalData.Cars;
        }
        else
        {
            cars = CarRentalData.Cars.Where(c => c.Addons?.ToString() == addons.ToLower()).ToList();
        }
        Print(cars);
        Console.ReadKey();
    }
    public static void PrintDetails(List<Car> cars)
>>>>>>> Stashed changes
    {
        while (true)
        {
<<<<<<< Updated upstream
            Console.WriteLine("Podaj nazwe auta:");
            List<Car> cars = new List<Car>();
            var addon = Console.ReadLine();
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

            Print(cars);
            ConsoleKeyInfo read = Console.ReadKey();
            if (read.Key == ConsoleKey.Escape) break;
=======
            Console.WriteLine("Brak samochodów o tych parametrach");
>>>>>>> Stashed changes
        }
    }

        public static void PrintDetails(List<Car> cars)
        {
            if (cars is null || cars.Count == 0)
            {
<<<<<<< Updated upstream
                  Console.WriteLine("Brak samochodów o  tych parametrach");
            }
            else
            {
                foreach (var car in cars)
                {
                    Console.WriteLine(car.GetDetails());
                }
=======
                Console.WriteLine(car.GetAddons());
>>>>>>> Stashed changes
            }
        }
    public static void Print(List<Car> cars)
    {
        if (cars is null || cars.Count == 0)
        {
            Console.WriteLine("Brak samochodów o tych parametrach");
        }
        else
        {
            foreach (var car in cars)
            {
                Console.WriteLine(car.GetAddons);
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
