using CarRental.ConsoleUI.Utils;
using CarRental.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.ConsoleUI
{
    internal static class ConsoleCarManager
    {

        private static readonly Dictionary<ConsoleKey, string> _menuOptions = new()
        {
            {ConsoleKey.A, "Marka"},
            {ConsoleKey.B, "Model"},
            {ConsoleKey.C, "Rocznik"},
            {ConsoleKey.D, "Liczba drzwi"},
            {ConsoleKey.E, "Cennik wynajęcia netto"},
            {ConsoleKey.F, "Liczba poduszek powietrznych"},
            {ConsoleKey.G, "Kilometraż"},
            {ConsoleKey.H, "Kolor nadwozia"},
            {ConsoleKey.I, "Zużycie paliwa - miasto"},
            {ConsoleKey.J, "Zużycie paliwa - trasa"},
            {ConsoleKey.K, "Skrzynia biegów - rodzaj"},
            {ConsoleKey.L, "Parametry silnika"},
            {ConsoleKey.M, "Numer rejestracyjny"},
            {ConsoleKey.N, "Numer VIN"},
            {ConsoleKey.O, "Klimatyzacja"},
            {ConsoleKey.P, "Segment"},
            {ConsoleKey.Q, "Dodatki"},
            {ConsoleKey.R, "Liczba miejsc z kierowcą"},
            {ConsoleKey.S, "Ścieżka do zdjęć samochodu"},
            {ConsoleKey.Escape, "Wyjdź"},
        };

        public static void Menu()
        {
            bool is_menu_on = true;
            while (is_menu_on)
            {
                Console.WriteLine("Uzupełnij poszczególne dane samochodu:");

                for (int i = 0; i < _menuOptions.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {_menuOptions.ElementAt(i).Value}");
                }

                ConsoleKeyInfo read = Console.ReadKey();

                switch (read.Key)
                {
                    case ConsoleKey.D1:
                        Console.WriteLine("opcja 1");
                        break;
                    case ConsoleKey.D2:
                        Console.WriteLine("opcja 2");
                        break;
                    case ConsoleKey.Escape:
                        is_menu_on = false;
                        break;
                    default: break;
                }
            }
        }

        public static void RunCreator()
        {
            do
                Console.ReadLine();
            //Menu();
            while (true);
        }
    }
}
