namespace CarRental.ConsoleUI;
internal static class ConsoleCarParamsReader
{
    // Class for getting car parameters values from console input
    public static string ReadCarMake()
    {
        string make;
        do
        {
            Console.Write("Podaj producenta: ");
            string? input = Console.ReadLine();
            make = input is not null ? input.Trim() : "";
        } while (false);
        return make;
    }

    public static string ReadCarModel()
    {
        string model;
        do
        {
            string? input = Console.ReadLine();
            model = input is not null ? input.Trim() : "";
        } while (false);
        return model;
    }

    public static string ReadCarColor()
    {
        string color;
        do
        {
            Console.Write("Podaj kolor nadwozia: ");
            string? input = Console.ReadLine();
            color = input is not null ? input.Trim() : "";
        } while (false);
        return color;
    }

    public static string ReadCarLicencePlate()
    {
        string licencePlateNumber;
        do
        {
            string? input = Console.ReadLine();
            licencePlateNumber = input is not null ? input.Trim() : "";
        } while (false);
        return licencePlateNumber;
    }

    public static string ReadCarVIN()
    {
        string vin;
        do
        {
            string? input = Console.ReadLine();
            vin = input is not null ? input.Trim() : "";
        } while (false);
        return vin;
    }

    public static string ReadCarTransmissionType()
    {
        string transmissionType;
        do
        {
            Console.Write("Podaj rodzaj skrzyni biegów: ");
            string? input = Console.ReadLine();
            transmissionType = input is not null ? input.Trim() : "";
        } while (false);
        return transmissionType;
    }

    public static string ReadCarFuelType()
    {
        string fuelType;
        do
        {
            Console.Write("Podaj rodzaj paliwa: ");
            string? input = Console.ReadLine();
            fuelType = input is not null ? input.Trim() : "";
        } while (false);
        return fuelType;
    }

    public static string ReadCarDisplacement()
    {
        string displacement;
        do
        {
            Console.Write("Podaj tekst pojemności silnika: ");
            string? input = Console.ReadLine();
            displacement = input is not null ? input.Trim() : "";
        } while (false);
        return displacement;
    }

    public static int ReadCarYear()
    {
        int presentYear = DateTime.Now.Year;
        int year;
        bool isAllGood;
        do
        {
            Console.Write("Podaj rocznik: ");
            bool isParsedWell = int.TryParse(Console.ReadLine(), out year);
            isAllGood = isParsedWell && (year <= presentYear);
        } while (!isAllGood);
        return year;
    }

    public static int ReadCarKilometrage()
    {
        int kilometrage;
        bool isAllGood;
        do
        {
            Console.Write("Podaj kilometraż: ");
            bool isParsedWell = int.TryParse(Console.ReadLine(), out kilometrage);
            isAllGood = isParsedWell && (kilometrage > 0);
        } while (!isAllGood);
        return kilometrage;
    }

    public static int ReadCarAirbags()
    {
        int airbags;
        bool isAllGood;
        do
        {
            bool isParsedWell = int.TryParse(Console.ReadLine(), out airbags);
            isAllGood = isParsedWell && (airbags > 0);
        } while (!isAllGood);
        return airbags;
    }

    public static int ReadCarSeatsNo()
    {
        int seats;
        bool isAllGood;
        do
        {
            bool isParsedWell = int.TryParse(Console.ReadLine(), out seats);
            isAllGood = isParsedWell && (seats > 0);
        } while (!isAllGood);
        return seats;
    }

    public static int ReadCarDoors()
    {
        int doors;
        bool isAllGood;
        do
        {
            Console.Write("Podaj liczbę drzwi: ");
            bool isParsedWell = int.TryParse(Console.ReadLine(), out doors);
            isAllGood = isParsedWell && (doors > 0);
        } while (!isAllGood);
        return doors;
    }

    public static float ReadCarPowerKw()
    {
        float powerKw;
        bool isAllGood;
        do
        {
            Console.Write("Podaj moc silnika w kilowatach: ");
            bool isParsedWell = float.TryParse(Console.ReadLine(), out powerKw);
            isAllGood = isParsedWell && (powerKw > 0);
        } while (!isAllGood);
        return powerKw;
    }

    public static float ReadCarFuelConsumption()
    {
        float fuelConsumption;
        bool isAllGood;
        do
        {
            bool isParsedWell = float.TryParse(Console.ReadLine(), out fuelConsumption);
            isAllGood = isParsedWell && (fuelConsumption > 0);
        } while (!isAllGood);
        return fuelConsumption;
    }

    public static float ReadCarPowerKm()
    {
        float powerKm;
        bool isAllGood;
        do
        {
            Console.Write("Podaj moc silnika w koniach mechanicznych: ");
            bool isParsedWell = float.TryParse(Console.ReadLine(), out powerKm);
            isAllGood = isParsedWell && (powerKm > 0);
        } while (!isAllGood);
        return powerKm;
    }

    public static float ReadCarTorque()
    {
        float torque;
        bool isAllGood;
        do
        {
            Console.Write("Podaj moment obrotowy silnika: ");
            bool isParsedWell = float.TryParse(Console.ReadLine(), out torque);
            isAllGood = isParsedWell && (torque > 0);
        } while (!isAllGood);
        return torque;
    }
}
