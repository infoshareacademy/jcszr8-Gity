using CarRental.DAL.Models;
using CarRental.DAL;
using CarRental.Logic;

namespace CarRental.ConsoleUI;
internal class ConsoleCarManager
{
    public static void Menu()
    {
        Console.Clear();
        string carMake = ReadMake();
        string carModel = ReadModel();
        string carLicensePlate = ReadLicensePlate();
        
        LogicCarManager.CreateCar(carMake, carModel, carLicensePlate);
    }

    public static string ReadMake()
    {
        bool success;
        string propertyValue;
        do
        {
            Console.WriteLine("Podaj markę: ");
            string? input = Console.ReadLine();
            propertyValue = input is not null ? input.Trim() : "";

            success = CarPropertyValidator.IsCarPropertyValid("make", propertyValue);
            if (success)
                break;
            Console.WriteLine("Błędna wartość, spróbuj ponownie...");
        } while (!success);

        return propertyValue;
    }

    public static string ReadModel()
    {
        bool success;
        string propertyValue;
        do
        {
            Console.WriteLine("Podaj model: ");
            string? input = Console.ReadLine();
            propertyValue = input is not null ? input.Trim() : "";

            success = CarPropertyValidator.IsCarPropertyValid("model", propertyValue);
            if (success)
                break;
            Console.WriteLine("Błędna wartość, spróbuj ponownie...");
        } while (!success);

        return propertyValue;
    }

    public static string ReadLicensePlate()
    {
        bool success;
        string propertyValue;
        do
        {
            Console.WriteLine("Podaj numer rejestracyjny: ");
            string? input = Console.ReadLine();
            propertyValue = input is not null ? input.Trim() : "";

            success = CarPropertyValidator.IsCarPropertyValid("license-plate-number", propertyValue);
            if (success)
                break;
            Console.WriteLine("Błędna wartość, spróbuj ponownie...");
        } while (!success);

        return propertyValue;
    }

    public static void CarSubMenu()
    {
        Console.Clear();
        Console.WriteLine("Tworzenie nowego samochodu (:quit - przerywa)");
        Console.WriteLine();

        Dictionary<string, string> rawCar = new();

        List<string> requiredProperties
            = new() { "make", "model", "license-plate-number" };

        foreach (string propertyName in requiredProperties)
        {
            string temp = ReadConsoleInputForCar(propertyName);
            if (Abort(temp)) break;
            rawCar.Add(propertyName, temp);
        }
        var model = rawCar.GetValueOrDefault("model");
        var make = rawCar.GetValueOrDefault("make");
        var plates = rawCar.GetValueOrDefault("license-plate-number");

        Console.WriteLine($"Wpisane dane: marka:{make}, model:{model}, numer rejestracyjny:{plates}");

        // TODO if all required params given

        Console.WriteLine("Czy chcesz uzupełnić opcjonalne parametry dla samochodu? (tak/nie): ");
        string input = Console.ReadLine().Trim().ToLower();
        if (input == "tak")
        {
            List<string> optionalProperties = new() { "year", "kilometrage", "doors", "price",
                "airbags", "color", "fuel-consumption", "transmission", "vin", "displacement",
                "seats", "fuel-type", "kw",
            };

            foreach (string propertyName in optionalProperties)
            {
                string temp = ReadConsoleInputForCar(propertyName);
                if (Abort(temp)) break;
                rawCar.Add(propertyName, temp);
            }
        }

        Console.WriteLine("..........tworzenie samochodu");

        // TODO do you want to create a car with these params
        // TODO create the car
    }

    public static bool Abort(string quit)
    {
        return quit.Trim() == ":quit";
    }

    public static string GetConsolePromptsForCar(string propertyName)
    {
        Dictionary<string, string> prompts = new()
        {
            // properties required for creating new car
            {"make", "Podaj markę samochodu: "},
            {"model", "Podaj model samochodu: " },
            {"license-plate-number", "Podaj numer rejestracyjny samochodu: " },
            // optional properties
            {"year", "Podaj rok produkcji: "},
            {"kilometrage", "Podaj stan licznika w kilometrach: "},
            {"doors", "Podaj liczbę drzwi: "},
            {"price", "Podaj cenę wypożyczenia: "},
            {"airbags", "Podaj liczbę poduszek powietrznych: "},
            {"color", "Podaj kolor nadwozia: "},
            {"fuel-consumption", @"Podaj spalanie miasto/trasa [l/100km] (np. ""6.5/4.5""): "},
            {"transmission", "Podaj rodzaj skrzyni biegów: "},
            {"vin", "Podaj numer VIN: "},
            {"displacement", "Podaj pojemność/oznaczenie silnika: " },
            {"seats", "Podaj liczbę miejsc z kierowcą: "},
            {"fuel-type", "Podaj rodzaj paliwa: " },
            { "kw", "Podaj moc w kilowatach: "},
             // TODO addons
            { "addons", "Podaj dodatki... :" },
        };


        return prompts[propertyName];
    }

    public static string ReadConsoleInputForCar(string carProperty)
    {
        var prompts = GetConsolePromptsForCar(carProperty);
        string promptForInput = prompts;
        string? propertyValue;
        bool success;
        do
        {
            Console.WriteLine(promptForInput);
            string? input = Console.ReadLine();
            propertyValue = input is not null ? input.Trim() : "";

            success = CarPropertyValidator.IsCarPropertyValid(carProperty, propertyValue);
            if (success)
                break;
            Console.WriteLine("Błędna wartość, spróbuj ponownie...");
        } while (!success);

        return propertyValue;
    }
}
