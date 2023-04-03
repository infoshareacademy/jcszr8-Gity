using CarRental.DAL;
using CarRental.DAL.Models;
using CarRental.Logic;
using System.Collections.Immutable;
using System.Data;
using System.Globalization;

namespace CarRental.ConsoleUI;
//przeniesc do logic czesci odpowiadajace za logike


public class Search
{

    public static void CarByMake()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Podaj nazwe auta:");
            var make = Console.ReadLine();
            var cars = LogicSearch.CarByMake(make);
            Print(cars);
            Leave();
            ConsoleKeyInfo read = Console.ReadKey();
            if (read.Key == ConsoleKey.Escape) break;
        }
    }

    public static void CarByProductionYear()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Podaj rok auta:");
            string readYear = Console.ReadLine();
            var cars = LogicSearch.CarByYear(readYear);
            Print(cars);
            Leave();
            ConsoleKeyInfo read = Console.ReadKey();
            if (read.Key == ConsoleKey.Escape) break;
        }
    }

    public static void CarByAvailable()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Wpisz datę w której chciałbyś rozpocząć wynajęcie: YYYY.MM.DD");
            var start = DateTime.ParseExact(Console.ReadLine(), "yyyy.MM.dd", CultureInfo.InvariantCulture);
            Console.WriteLine("Wpisz datę w której chciałbyś zakończyć wynajęcie: YYYY.MM.DD");
            DateTime end = DateTime.ParseExact(Console.ReadLine(), "yyyy.MM.dd", CultureInfo.InvariantCulture);
            var carIds = Rentals.GetAvailableCarIds(start, end);

            if (start == null)
            {
                Console.WriteLine("Nie uzupełniłeś daty");
            }
            else
            {
                var value = Rentals.ListOfAvailableCarForRent(carIds);
                foreach(var car in value) 
                {
                    Console.WriteLine(car.ToString());

                }
                Console.ReadLine();
            }
            ConsoleKeyInfo read = Console.ReadKey();
            if (read.Key == ConsoleKey.Escape) break;
        }
    }

    public static void CarByAddon()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Podaj jakie wyposażenie cie interesuje:");
            var addon = Console.ReadLine();
            var cars = LogicSearch.CarByAddons(addon);
            Print(cars);
            Leave();
            ConsoleKeyInfo read = Console.ReadKey();
            if (read.Key == ConsoleKey.Escape) break;
        }
    }

    public static void PrintDetails(List<CarModel> cars)
    {
        if (cars is null || cars.Count == 0)
        {
            Console.WriteLine("Brak samochodów o tych parametrach");
        }
        else
        {
            foreach (var car in cars)
            {
                Console.WriteLine(car.GetDetails());
            }
        }
    }
    public static void Print(List<CarModel> cars)
    {
        if (cars is null || cars.Count == 0)
        {
            Console.WriteLine("Brak samochodów o tych parametrach");
        }
        else
        {
            Console.WriteLine(LogicSearch.Print(cars));
        }
    }
    //Zastępstwo za przyszłe funkcje
    public static void PlaceHolder()
    {
        Console.WriteLine("PlaceHolder");
        Leave();
        Console.ReadKey();
    }

    internal static void Leave()
    {
        Console.WriteLine("Aby wyjść wciśnij ESC");
    }
}
