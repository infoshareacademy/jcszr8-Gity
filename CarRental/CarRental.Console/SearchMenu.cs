using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.ConsoleUI
{
    public class SearchMenu
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
        private static int activePosition = 1;
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

            string welcome = "Wyszukuj auta!";
            Console.WriteLine();
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
                        Console.Write(" ESC. ");
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
                    Search.CarByProductionYear();
                    break;
                case 2:
                    Console.Clear();
                    Search.CarByMake();
                    break;
                case 3:
                    Console.Clear();
                    Search.PlaceHolder();
                    break;
                case 4:
                    Console.Clear();
                    Search.PlaceHolder();
                    break;
                case 5:
                    Console.Clear();
                    Search.CarByAddon();
                    break;
                case 6:
                    MainMenu.StartMenu();
                    break;
                default:
                    break;
            }
        }
    }
}
