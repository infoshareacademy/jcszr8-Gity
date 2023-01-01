using CarRental.ConsoleUI.Utils;
using CarRental.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.ConsoleUI;
internal static class ConsoleCarManager
{
    public static CarDto carDto = new();
    private static readonly Dictionary<ConsoleKey, string> _menuOptions = new()
        {
            {ConsoleKey.A, $"Marka"},
            // {ConsoleKey.A, $"Marka --- {carDto.Make}"}, <-- dlaczego to nie działa (nie aktualizuje Make)?
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
            {ConsoleKey.Z, "ZASTOSUJ PARAMETRY I DODAJ SAMOCHÓD DO ZASOBÓW"},
            {ConsoleKey.Escape, "Wyjdź"},
        };
    public static void Menu()
    {

        bool is_menu_on = true;
        while (is_menu_on)
        {
            Console.Clear();
            Console.WriteLine("Uzupełnij poszczególne dane samochodu:");

            var tempMenuOptions = _menuOptions;

            foreach (KeyValuePair<ConsoleKey, string> kv in _menuOptions)
            {
                Console.WriteLine($"{kv.Key.ToString().ToUpper()}. {kv.Value}");
            }

            Console.WriteLine();
            Console.WriteLine(carDto.ToString());

            ConsoleKeyInfo read = Console.ReadKey(true);
            switch (read.Key)
            {
                case ConsoleKey.A:
                    carDto.Make = ConsoleCarParamsReader.ReadCarMake();
                    break;
                case ConsoleKey.B:
                    Console.Write("Podaj model: ");
                    carDto.Model = ConsoleCarParamsReader.ReadCarModel();
                    break;
                case ConsoleKey.C:
                    carDto.Year = ConsoleCarParamsReader.ReadCarYear();
                    break;
                case ConsoleKey.D:
                    carDto.Doors = ConsoleCarParamsReader.ReadCarDoors();
                    break;
                case ConsoleKey.E:
                    //carDto.Pricing = ConsoleCarParamsReader.ReadCarPricing();
                    break;
                case ConsoleKey.F:
                    Console.Write("Podaj liczbę poduszek powietrznych: ");
                    carDto.Airbags = ConsoleCarParamsReader.ReadCarAirbags();
                    break;
                case ConsoleKey.G:
                    carDto.Kilometrage = ConsoleCarParamsReader.ReadCarKilometrage();
                    break;
                case ConsoleKey.H:
                    carDto.Color = ConsoleCarParamsReader.ReadCarColor();
                    break;
                case ConsoleKey.I:
                    Console.Write("Podaj spalanie w mieście [l/100km]: ");
                    carDto.FuelConsumptionCity = ConsoleCarParamsReader.ReadCarFuelConsumption();
                    break;
                case ConsoleKey.J:
                    Console.Write("Podaj spalanie na trasie [l/100km]: ");
                    carDto.FuelConsumptionHighway = ConsoleCarParamsReader.ReadCarFuelConsumption();
                    break;
                case ConsoleKey.K:
                    Console.WriteLine("Podaj rodzaj skrzyni biegów: ");
                    carDto.Transmission = ConsoleCarParamsReader.ReadCarTransmissionType();
                    break;
                case ConsoleKey.L:
                    // parametry silnika
                    break;
                case ConsoleKey.M:
                    Console.WriteLine("Podaj numer rejestracyjny: ");
                    carDto.LicencePlateNumber = ConsoleCarParamsReader.ReadCarLicencePlate();
                    break;
                case ConsoleKey.N:
                    Console.WriteLine("Podaj numer VIN: ");
                    carDto.VIN = ConsoleCarParamsReader.ReadCarVIN();
                    break;
                case ConsoleKey.O:
                    Console.WriteLine("Klimatyzacja (tak/nie): ------");
                    //carDto.Ac = ConsoleCarParamsReader.ReadCarAc();
                    break;
                case ConsoleKey.P:
                    Console.WriteLine("Podaj segment: --------");
                    //carDto.Segment = ConsoleCarParamsReader.ReadCarSegment();
                    break;
                case ConsoleKey.Q:
                    Console.WriteLine("Podaj dodatki: ----------");
                    //carDto.Addons = ConsoleCarParamsReader.ReadCarAddons();
                    break;
                case ConsoleKey.R:
                    Console.WriteLine("Podaj liczbę miejsc z kierowcą: ");
                    carDto.SeatsNo = ConsoleCarParamsReader.ReadCarSeatsNo();
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
