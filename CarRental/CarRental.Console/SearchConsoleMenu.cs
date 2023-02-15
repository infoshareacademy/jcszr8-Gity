using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.ConsoleUI
{
    public class SearchConsoleMenu
    {
        private static readonly Dictionary<ConsoleKey, string> _menuOptions = new()
        {
            {ConsoleKey.D1, "Wyszukaj samochód po roczniku."},
            {ConsoleKey.D2, "Wyszukaj samochód po nazwie."},
            {ConsoleKey.D3, "Wyszukaj samochód po dacie dostępności."},
            {ConsoleKey.D4, "Wyszukaj samochód do wypożyczenia po nazwie."},
            {ConsoleKey.D5, "Wyszukaj samochód po wyposażeniu."},
            {ConsoleKey.Escape, "Wyjdź"},
        };
        public static void Menu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Witaj w naszej wypożyczalni");
                Console.WriteLine("Wybierz opcję:");

                for (int i = 0; i < _menuOptions.Count; i++)
                {
                    if (i == 5)
                    {
                        Console.WriteLine($"ESC. {_menuOptions.ElementAt(i).Value}");
                    }
                    else
                        Console.WriteLine($"{i + 1}. {_menuOptions.ElementAt(i).Value}"); ;
                }
                ConsoleKeyInfo read = Console.ReadKey(true);
                Console.WriteLine();
                switch (read.Key)
                {
                    case ConsoleKey.D1:
                        Console.Clear();
                        Search.CarByProductionYear();
                        break;
                    case ConsoleKey.D2:
                        Console.Clear();
                        Search.CarByMake();
                        break;
                    case ConsoleKey.D3:
                        Console.Clear();
                        Search.PlaceHolder();
                        break;
                    case ConsoleKey.D4:
                        Console.Clear();
                        Search.PlaceHolder();
                        break;
                    case ConsoleKey.D5:
                        Console.Clear();
                        Search.PlaceHolder();
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
}
