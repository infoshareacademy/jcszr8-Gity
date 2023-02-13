using CarRental.DAL.Models;
using CarRental.DAL;
using CarRental.Logic;
using CarRental.DAL.Enums;
using System.Text;

namespace CarRental.ConsoleUI;
internal class ConsoleCarManager
{
    private static readonly Dictionary<ConsoleKey, string> _menuOptions = new()
    {
        {ConsoleKey.D1, "Rok produkcji."},
        {ConsoleKey.D2, "Kilometraż."},
        {ConsoleKey.D3, "Liczba drzwi."},
        {ConsoleKey.D4, "Cena wypożyczenia."},
        {ConsoleKey.D5, "Poduszki powietrzne."},
        {ConsoleKey.D6, "Kolor nadwozia."},
        {ConsoleKey.D7, "Spalanie."},
        {ConsoleKey.D8, "Skrzynia biegów."},
        {ConsoleKey.D9, "Oznaczenie silnika (pojemność)."},
        {ConsoleKey.A, "Liczba pasażerów."},
        {ConsoleKey.B, "Rodzaj paliwa."},
        {ConsoleKey.C, "Moc w Kilowatach."},
        {ConsoleKey.D, "Dodatki."},
        {ConsoleKey.Escape, "Wyjdź"},
    };
    public static void AddNewCarMenu()
    {
        Console.Clear();
        string carMake = ReadCarProperty("make", "Podaj markę: ");
        string carModel = ReadCarProperty("model", "Podaj model: ");
        string carLicensePlate = ReadCarProperty("license-plate-number", "Podaj numer rejestracyjny: ");

        LogicCarManager.CreateCar(carMake, carModel, carLicensePlate);

        Console.WriteLine("Nowy samochód został dodany");
    }

    public static string ReadCarProperty(string propertyName, string prompt)
    {
        bool success;
        string propertyValue;
        do
        {
            Console.WriteLine(prompt);
            string? input = Console.ReadLine();
            propertyValue = input is not null ? input.Trim() : "";

            success = CarPropertyValidator.IsCarPropertyValid(propertyName, propertyValue);
            if (success)
                break;
            Console.WriteLine("Błędna wartość, spróbuj ponownie...");
        } while (!success);

        return propertyValue;
    }

    public static Car GetCarToEdit()
    {
        Console.Clear();
        Console.Write("Podaj id samochodu do edycji: ");
        int carId = int.Parse(Console.ReadLine());

        var car = LogicCarManager.GetById(carId);

        Console.WriteLine("Szczegóły edytowanego samochodu:");
        Console.WriteLine(car.GetDetails());
        Console.ReadLine();
        return car;
    }

    public static void EditMenu()
    {
        var car = GetCarToEdit();

        bool menu_on = true;

        while (menu_on)
        {
            Console.Clear();
            Console.WriteLine("Wybierz właściwość do edycji:");

            for (int i = 0; i < _menuOptions.Count; i++)
            {
                if (i == _menuOptions.Count - 1)
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
                    string year = ReadCarProperty("year", "Podaj rok produkcji: ");
                    car.Year = int.Parse(year);
                    break;
                case ConsoleKey.D2:
                    Console.Clear();
                    string kilometrage = ReadCarProperty("kilometrage", "Podaj kilometraż: ");
                    car.Kilometrage = int.Parse(kilometrage);
                    break;
                case ConsoleKey.D3:
                    Console.Clear();
                    string doors = ReadCarProperty("doors", "Podaj liczbę drzwi: ");
                    car.Doors = int.Parse(doors);
                    break;
                case ConsoleKey.D4:
                    Console.Clear();
                    string price = ReadCarProperty("price", "Podaj cenę wypożyczenia: ");
                    car.Price = decimal.Parse(price);
                    break;
                case ConsoleKey.D5:
                    Console.Clear();
                    string airbags = ReadCarProperty("airbags", "Podaj liczbę poduszek powietrznych: ");
                    car.Airbags = int.Parse(airbags);
                    break;
                case ConsoleKey.D6:
                    Console.Clear();
                    string color = ReadCarProperty("color", "Podaj kolor nadwozia: ");
                    car.Color = color;
                    break;
                case ConsoleKey.D7:
                    Console.Clear();
                    string fuelConsumption = ReadCarProperty("fuel-consumption", "Podaj spalanie: ");
                    car.FuelConsumption = fuelConsumption;
                    break;
                case ConsoleKey.D8:
                    Console.Clear();
                    string transmission = ReadCarProperty("transmission", "Podaj rodzaj skrzyni biegów: ");
                    car.Transmission = transmission;
                    break;
                case ConsoleKey.D9:
                    Console.Clear();
                    string displacement = ReadCarProperty("displacement", "Podaj oznaczenie pojemności silnika: ");
                    car.EngineParameters.Displacement = displacement;
                    break;
                case ConsoleKey.A:
                    Console.Clear();
                    string seats = ReadCarProperty("seats", "Podaj liczbę miejsc z kierowcą: ");
                    car.SeatsNo = int.Parse(seats);
                    break;
                case ConsoleKey.B:
                    Console.Clear();
                    string fuelType = ReadCarProperty("fuel-type", "Podaj rodzaj paliwa: ");
                    car.EngineParameters.Type = Enum.Parse<EngineType>(fuelType);
                    break;
                case ConsoleKey.C:
                    Console.Clear();
                    string powerInKw = ReadCarProperty("kw", "Podaj moc w kilowatach: ");
                    car.EngineParameters.PowerInKiloWats = float.Parse(powerInKw);
                    break;
                case ConsoleKey.D:
                    Console.Clear();
                    AddonsMenu();
                    break;
                case ConsoleKey.Escape:
                    menu_on = false;
                    break;
                default:
                    break;
            }
        }
    }

    public static void AddonsMenu()
    {

    }
}
