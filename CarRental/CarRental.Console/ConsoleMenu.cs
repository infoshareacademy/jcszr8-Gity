using CarRental.DAL;
using CarRental.DAL.Models;

namespace CarRental.ConsoleUI;
public class ConsoleMenu
{
    private static readonly Dictionary<ConsoleKey, string> _menuOptions = new()
        {
            {ConsoleKey.D1, "Pokaż listę samochodów."},
            {ConsoleKey.D2, "Wyszukaj samochód po roczniku."},
            {ConsoleKey.D3, "Wyszukaj samochód po nazwie."},
            {ConsoleKey.D4, "Wyszukaj samochód po dacie dostępności."},
            {ConsoleKey.D5, "Wyszukaj samochód do wypożyczenia po nazwie."},
            {ConsoleKey.D6, "Wyszukaj samochód po wyposażeniu."},
            {ConsoleKey.D7, "Dodaj samochód."},
            {ConsoleKey.D8, "Pokaż wypożyczenia."},
            {ConsoleKey.D9, "Dodaj wypożeczenie."},
            {ConsoleKey.D0, "Edytuj wypożyczenie."},
            {ConsoleKey.F1, "Edytuj dane samochodu."},
            {ConsoleKey.Escape, "Wyjdź"},
        };
    public static void Menu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Witaj w naszej wypożyczalni");
            Console.WriteLine("Choose option by writing the number:");

            for (int i = 0; i < _menuOptions.Count; i++)
            {
                if (i == 9)
                {
                    Console.WriteLine($"0. {_menuOptions.ElementAt(i).Value}");
                }
                else if (i == 10)
                {
                    Console.WriteLine($"F1. {_menuOptions.ElementAt(i).Value}");
                }
                else if (i == 11)
                {
                    Console.WriteLine($"ESC. {_menuOptions.ElementAt(i).Value}");
                }
                else
                    Console.WriteLine($"{i + 1}. {_menuOptions.ElementAt(i).Value}");
            }
            ConsoleKeyInfo read = Console.ReadKey();
            Console.WriteLine();
            switch (read.Key)
            {
                case ConsoleKey.D1:
                    var cars = CarRentalData.Cars;
                    DataMigrator.PrintListOfItems<Car>(cars);
                    Console.ReadKey();
                    break;
                case ConsoleKey.D2:
                    Confirmation(); Console.Clear(); Search.CarByProductionYear();
                    break;
                case ConsoleKey.D3:
                    Confirmation(); Console.Clear(); Search.CarByMake();
                    break;
                case ConsoleKey.D4:
                    Confirmation(); Console.Clear(); Search.PlaceHolder();
                    break;
                case ConsoleKey.D5:
                    Confirmation(); Console.Clear(); Search.PlaceHolder();
                    break;
                case ConsoleKey.D6:
                    Confirmation(); Console.Clear(); Search.PlaceHolder();
                    break;
                case ConsoleKey.D7:
                    Console.Clear();
                    ConsoleCarManager.Menu();
                    break;
                case ConsoleKey.D8:
                    Confirmation(); Console.Clear(); Search.PlaceHolder();
                    break;
                case ConsoleKey.D9:
                    Confirmation(); Console.Clear(); Search.PlaceHolder();
                    break;
                case ConsoleKey.D0:
                    Confirmation(); Console.Clear(); Search.PlaceHolder();
                    break;
                case ConsoleKey.F1:
                    Confirmation(); Console.Clear(); Search.PlaceHolder();
                    break;
                case ConsoleKey.Escape:
                    Environment.Exit(0);
                    break;
                default: break;
            }
        }
    }

    public static void Confirmation()
    {
        Console.WriteLine("Czy napewno chcesz wybrac ta opcje?: T/N");
        ConsoleKeyInfo conf = Console.ReadKey();
        while (true)
        {
            if (conf.Key == ConsoleKey.T) break;
            else if (conf.Key == ConsoleKey.N) Menu();
            else
                Console.WriteLine();
            Console.WriteLine("Nieprawidłowa komenda");
            Thread.Sleep(600);
            Menu();
        }
    }
}
