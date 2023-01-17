using CarRental.DAL;
using CarRental.DAL.Enums;
using CarRental.DAL.Models;
using CarRental.Logic;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace CarRental.ConsoleUI;
internal static class ConsoleCarManager
{
    public static void GetUserInputForNewCar()
    {
        Console.Clear();
        Console.WriteLine("Podaj dane samochodu: ");
        Console.WriteLine();
        Console.WriteLine("DANE OBOWIĄZKOWE:");

        bool makeIsValid;
        string? carMake;
        do
        {
            makeIsValid = ParseCarMake(out carMake);
        } while (!makeIsValid);

        Console.WriteLine($"Car make is: {carMake}");

        Console.WriteLine("DANE OPCJONALNE:");
    }

    private static bool ParseCarMake(out string carMake)
    {
        Console.WriteLine("Podaj producenta: ");

        string input = Console.ReadLine();

        carMake = "";

        return false; // TODO 
    }

    public static void CarSubMenu()
    {
        Console.Clear();
        Console.WriteLine("Tworzenie nowego samochodu (:q - przerywa)");
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

        Console.WriteLine($"Dodać nowy samochód {rawCar["make"]} " +
            $"{rawCar["model"]} {rawCar["licensePlateNumber"]} ? tak/nie");

        Console.WriteLine("Czy chcesz uzupełnić opcjonalne parametry dla samochodu? (tak/nie): ");
        string input = Console.ReadLine().Trim().ToLower();
        if (input == "tak")
        {
            List<string> optionalProperties = new() { };

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
            {"fuel", @"Podaj spalanie miasto/trasa [l/100km] (np. ""6.5/4.5"": "},
            {"transmission", "Podaj rodzaj skrzyni biegów: "},
            {"vin", "Podaj numer VIN: "},
            {"ac", "Czy posiada klimatyzację (tak/nie): " },
            {"displacement", "Podaj pojemność/oznaczenie silnika: " },
            {"seats", "Podaj liczbę miejsc z kierowcą: "},
            {"fuel-type", "Podaj rodzaj paliwa: " },
            { "kw", "Podaj moc w kilowatach: "},
             // TODO addons
            { "addons", "Podaj dodatki... :" },
        };

        //carDto.EngineType = (EngineType)Enum.Parse(typeof(EngineType),
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

    public static int GetNextAvailableId()
    {
        return CarRentalData.Cars.Max(x => x.Id) + 1;
    }
}
