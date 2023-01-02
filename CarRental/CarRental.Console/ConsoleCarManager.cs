using CarRental.DAL;
using CarRental.DAL.Models;

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
            {ConsoleKey.E, "Cena wypożyczenia samochodu"},
            {ConsoleKey.F, "Liczba poduszek powietrznych"},
            {ConsoleKey.G, "Kilometraż"},
            {ConsoleKey.H, "Kolor nadwozia"},
            {ConsoleKey.I, "Zużycie paliwa miasto/trasa"},
            {ConsoleKey.J, "---"},
            {ConsoleKey.K, "Skrzynia biegów - rodzaj"},
            {ConsoleKey.L, "Parametry silnika"},
            {ConsoleKey.M, "Numer rejestracyjny"},
            {ConsoleKey.N, "Numer VIN"},
            {ConsoleKey.O, "Klimatyzacja"},
            {ConsoleKey.P, "---"},
            {ConsoleKey.Q, "Dodatki"},
            {ConsoleKey.R, "Liczba miejsc wraz z kierowcą"},
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
                    Console.Write("Podaj producenta: ");
                    carDto.Make = ConsoleCarParamsReader.ReadCarMake();
                    break;
                case ConsoleKey.B:
                    Console.Write("Podaj model: ");
                    carDto.Model = ConsoleCarParamsReader.ReadCarModel();
                    break;
                case ConsoleKey.C:
                    Console.Write("Podaj rocznik: ");
                    carDto.Year = ConsoleCarParamsReader.ReadCarYear();
                    break;
                case ConsoleKey.D:
                    Console.Write("Podaj liczbę drzwi: ");
                    carDto.Doors = ConsoleCarParamsReader.ReadCarDoors();
                    break;
                case ConsoleKey.E:
                    Console.WriteLine("Podaj cenę wypożyczenia: ");
                    carDto.Pricing = ConsoleCarParamsReader.ReadCarPricing();
                    break;
                case ConsoleKey.F:
                    Console.Write("Podaj liczbę poduszek powietrznych: ");
                    carDto.Airbags = ConsoleCarParamsReader.ReadCarAirbags();
                    break;
                case ConsoleKey.G:
                    Console.Write("Podaj kilometraż: ");
                    carDto.Kilometrage = ConsoleCarParamsReader.ReadCarKilometrage();
                    break;
                case ConsoleKey.H:
                    Console.Write("Podaj kolor nadwozia: ");
                    carDto.Color = ConsoleCarParamsReader.ReadCarColor();
                    break;
                case ConsoleKey.I:
                    Console.Write(@"Podaj spalanie miasto/trasa [l/100km] (np. ""6.5/4.5"": ");
                    carDto.FuelConsumption = ConsoleCarParamsReader.ReadCarFuelConsumption();
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
                    break;
                case ConsoleKey.Q:
                    Console.WriteLine("Podaj dodatki: ----------");
                    //carDto.Addons = ConsoleCarParamsReader.ReadCarAddons();
                    break;
                case ConsoleKey.R:
                    Console.WriteLine("Podaj liczbę miejsc z kierowcą: ");
                    carDto.SeatsNo = ConsoleCarParamsReader.ReadCarSeatsNo();
                    break;
                case ConsoleKey.Z:
                    Console.WriteLine("Tworzę nowy samochód w systemie...");
                    var newCar = RunCreator(carDto);
                    CarRentalData.Cars.Add(newCar);
                    Console.WriteLine("Nowy samochód został dodany do zasobów.");
                    Console.ReadLine();
                    break;
                case ConsoleKey.Escape:
                    is_menu_on = false;
                    break;
                default: break;
            }
        }
    }

    public static Car RunCreator(CarDto carDto)
    {
        Car newCar = new()
        {
            Id = GetNextAvailableId(),
            Make = carDto.Make,
            Model = carDto.Model,
            Year = carDto.Year,
            Doors = carDto.Doors,
            Addons = carDto.Addons,
            Airbags = carDto.Airbags,
            Color = carDto.Color,
            Ac = carDto.Ac,
            EngineParameters = carDto.EngineParameters,
            FuelConsumption = carDto.FuelConsumption,
            Kilometrage = carDto.Kilometrage,
            LicencePlateNumber = carDto.LicencePlateNumber,
            Pricing = carDto.Pricing,
            SeatsNo = carDto.SeatsNo,
            Transmission = carDto.Transmission,
            VIN = carDto.VIN,
        };
        return newCar;
    }

    public static int GetNextAvailableId()
    {
        return CarRentalData.Cars.Max(x => x.Id) + 1;
    }
}
