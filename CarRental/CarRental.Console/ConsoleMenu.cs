using CarRental.DAL;
using CarRental.DAL.Models;

namespace CarRental.ConsoleUI;
public class ConsoleMenu
{
    private static readonly Dictionary<ConsoleKey, string> _menuOptions = new()
        {
            {ConsoleKey.D1, "Pokaż listę samochodów."},
            {ConsoleKey.D2, "Wyszukaj samochód"},
            {ConsoleKey.D3, "Dodaj samochód."},
            {ConsoleKey.D4, "Pokaż wypożyczenia."},
            {ConsoleKey.D5, "Dodaj wypożeczenie."},
            {ConsoleKey.D6, "Edytuj wypożyczenie."},
            {ConsoleKey.D7, "Edytuj dane samochodu."},
            {ConsoleKey.Escape, "Wyjdź"},
        };
    public static void Menu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Witaj w naszej wypożyczalni");
            Console.WriteLine("Wybierz opcje podając numer");

            for (int i = 0; i < _menuOptions.Count; i++)
            {
                if (i == 7)
                {
                    Console.WriteLine($"ESC. {_menuOptions.ElementAt(i).Value}");
                }
                else
                    Console.WriteLine($"{i + 1}. {_menuOptions.ElementAt(i).Value}");
            }
            ConsoleKeyInfo read = Console.ReadKey(true);
            Console.WriteLine();
            switch (read.Key)
            {
                case ConsoleKey.D1:
                    Console.Clear();
                    var cars = CarRentalData.Cars;
                    DataMigrator.PrintListOfItems<Car>(cars);
                    Console.ReadKey();
                    break;
                case ConsoleKey.D2:
                    Console.Clear();
                    SearchConsoleMenu.Menu();
                    break;
                case ConsoleKey.D3:
                    Console.Clear();
                    ConsoleCarManager.CarSubMenu();
                    break;
                case ConsoleKey.D4:
                    Console.Clear();
                    Search.PlaceHolder();
                    break;
                case ConsoleKey.D5:
                    Console.Clear();
                    Search.PlaceHolder();
                    break;
                case ConsoleKey.D6:
                    Console.Clear();
                    Search.PlaceHolder();
                    break;
                case ConsoleKey.D7:
                    Console.Clear();
                    ConsoleCarManager.CarSubMenu();
                    break;
                case ConsoleKey.Escape:
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
        }
    }
}
