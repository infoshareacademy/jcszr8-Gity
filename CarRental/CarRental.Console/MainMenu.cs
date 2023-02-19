using CarRental.DAL;
using CarRental.DAL.Models;
using CarRental.Logic;

namespace CarRental.ConsoleUI;
public class MainMenu
{
    private static readonly Dictionary<ConsoleKey, string> _menuOptions = new()
        {
            {ConsoleKey.D1, "Pokaż listę samochodów."},
            {ConsoleKey.D2, "Wyszukaj samochód."},
            {ConsoleKey.D3, "Dodaj samochód."},
            {ConsoleKey.D4, "Pokaż wypożyczenia."},
            {ConsoleKey.D5, "Dodaj wypożyczenie."},
            {ConsoleKey.D6, "Edytuj wypożyczenie."},
            {ConsoleKey.D7, "Edytuj dane samochodu."},
            {ConsoleKey.Escape, "Wyjdź"},
        };
    private static int activePosition = 1;
    public static string logo = @"
   _____             _____            _        _ 
  / ____|           |  __ \          | |      | |
 | |     __ _ _ __  | |__) |___ _ __ | |_ __ _| |
 | |    / _` | '__| |  _  // _ \ '_ \| __/ _` | |
 | |___| (_| | |    | | \ \  __/ | | | || (_| | |
  \_____\__,_|_|    |_|  \_\___|_| |_|\__\__,_|_|
                                                 ";
    public static void StartMenu()
    {
        Console.CursorVisible = false;
        while (true)
        {
            DisplayMenu();
            SelectOption();
            RunOption();
        }
    }
    public static void DisplayMenu()
    {
        const ConsoleColor BG = ConsoleColor.Gray;
        const ConsoleColor BG_ACTIVE = ConsoleColor.DarkCyan;
        const ConsoleColor FG = ConsoleColor.DarkCyan;
        const ConsoleColor FG_ACTIVE = ConsoleColor.White;

        Console.BackgroundColor = BG;
        Console.Clear();
        Console.ForegroundColor = FG;

        string welcome = "Witaj w wypożyczalni!";
        Console.WriteLine(logo);
        Console.SetCursorPosition((Console.WindowWidth - welcome.Length) / 2, Console.CursorTop);
        Console.WriteLine(welcome);
        Console.WriteLine();
        Console.WriteLine(" Wybierz opcję:");
        Console.WriteLine();

        for (int i = 1; i <= _menuOptions.Count; i++)
        {
            if (activePosition == i)
            {
                Console.BackgroundColor = BG_ACTIVE;
                Console.ForegroundColor = FG_ACTIVE;
                if (i == _menuOptions.Count)
                {
                    Console.Write($" ESC. ");
                }
                else
                {
                    Console.Write($" {i}. ");
                }
                Console.WriteLine("{0,-35}", _menuOptions.ElementAt(i - 1).Value);
                Console.BackgroundColor = BG;
                Console.ForegroundColor = FG;
            }
            else
            {
                if (i == _menuOptions.Count)
                {
                    Console.Write(" ESC.");
                }
                else
                {
                    Console.Write($" {i}. ");
                }
                Console.WriteLine(_menuOptions.ElementAt(i - 1).Value);
            }
        }
    }
    public static void SelectOption()
    {
        do
        {
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key == ConsoleKey.UpArrow)
            {
                activePosition = (activePosition > 1) ? --activePosition : _menuOptions.Count;
                DisplayMenu();
            }
            else if (key.Key == ConsoleKey.DownArrow)
            {
                activePosition = (activePosition % _menuOptions.Count) + 1;
                DisplayMenu();
            }
            else if (key.Key == ConsoleKey.Escape)
            {
                activePosition = _menuOptions.Count;
                break;
            }
            else if (key.Key == ConsoleKey.Enter)
            {
                break;
            }
            else
            {
                if (key.Key == ConsoleKey.D1) activePosition = 1;
                if (key.Key == ConsoleKey.D2) activePosition = 2;
                if (key.Key == ConsoleKey.D3) activePosition = 3;
                if (key.Key == ConsoleKey.D4) activePosition = 4;
                if (key.Key == ConsoleKey.D5) activePosition = 5;
                if (key.Key == ConsoleKey.D6) activePosition = 6;
                if (key.Key == ConsoleKey.D7) activePosition = 7;
                if (key.Key == ConsoleKey.D8) activePosition = 8;
                break;
            }
        } while (true);
    }
    public static void RunOption()
    {
        switch (activePosition)
        {
            case 1:
                Console.Clear();
                var cars = CarRentalData.Cars;
                //Search.PrintListOfItems<Car>(cars);
                Console.WriteLine(LogicCarManager.CarsToTableString());
                Console.ReadKey();
                break;
            case 2:
                Console.Clear();
                SearchMenu.StartMenu();
                break;
            case 3:
                Console.Clear();
                ConsoleCarManager.AddNewCarMenu();
                break;
            case 4:
                Console.Clear();
                Console.WriteLine(RentalManager.RentalsToTableString());
                Console.ReadLine();
                break;
            case 5:
                Console.Clear();
                Search.PlaceHolder();
                break;
            case 6:
                Console.Clear();
                Search.PlaceHolder();
                break;
            case 7:
                Console.Clear();
                ConsoleCarManager.EditMenu();
                break;
            default:
                Environment.Exit(0);
                break;
        }
    }
}
