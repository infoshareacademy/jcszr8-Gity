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

    //ToLogic
    public static List<int> GetAvailableCarIds(DateTime start, DateTime end)
    {

        var cars1 = GetNotRented();
        var cars2 = GetAvailableInGivenTime(start, end);
        var allIdCars = cars1.Concat(cars2).Distinct().ToList();
        return allIdCars;
    }

    public static List<Car> ListOfAvailableCarForRent(List<int> carIds)

    {
        var carsToRent = new List<Car>();

        foreach (var carId in carIds)
        {
            var car = CarRentalData.Cars.Where(c => c.Id == carId).ToList();
            foreach(var item in car) 
            {
                carsToRent.Add(item);
            }
        }
        return carsToRent;
    }


    public static List<int> GetNotRented()
    {
        // zwraca te, które w ogóle nie występują  w liście wypożyczonych
        // te auta, których id nie występują w liście wypożyczonych
        var rentedIds = CarRentalData.Rentals.Select(r => r.CarId).ToList();
        var carIds = CarRentalData.Cars.Select(c => c.Id).ToList();

        var availableCars = carIds.Except(rentedIds).ToList();

        return availableCars;

    }

    public static List<int> GetAvailableInGivenTime(DateTime start, DateTime end)
    {

        var found = CarRentalData.Rentals.Where(r =>
           (end < r.BeginDate) ||
           (start > r.EndDate)
           ).Select(r => r.CarId).ToList(); // W efekcie dostaniemy listę wypożyczeń poza zadanym czasem
        return found;
    }
    //ToLogic



    public static void CarByAvailable()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Wpisz datę w której chciałbyś rozpocząć wynajęcie: YYYY.MM.DD");
            var start = DateTime.ParseExact(Console.ReadLine(), "yyyy.MM.dd", CultureInfo.InvariantCulture);
            Console.WriteLine("Wpisz datę w której chciałbyś zakończyć wynajęcie: YYYY.MM.DD");
            DateTime end = DateTime.ParseExact(Console.ReadLine(), "yyyy.MM.dd", CultureInfo.InvariantCulture);
            List<Rental> rentals = new List<Rental>();
            List<Car> cars = new List<Car>();

            var allRentals = CarRentalData.Rentals;

            var carIds = GetAvailableCarIds(start, end);

            if (start == null)
                Console.WriteLine("Nie uzupełniłeś daty");
            else
            {
                var value = ListOfAvailableCarForRent(carIds);
                foreach(var car in value) 
                {
                    Console.WriteLine(car.ToString());

                }
                Console.ReadLine();
                


                // r.Start Start r.End End

                //rentals = CarRentalData.Rentals.Where(r => r.EndDate >= start && r => ).ToList();
            }
            //foreach (var ren in rentals)
            //{

            //      (cars.Where(c => c.Id == ren);
            //};



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

    public static void PrintDetails(List<Car> cars)
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
                Console.WriteLine(car.ToString());
            }
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
