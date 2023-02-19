using CarRental.DAL;

namespace CarRental.ConsoleUI;
internal class Program
{
        static void Main(string[] args)
    {
        Console.Title = AppConfig.APP_NAME;

        MainMenu.StartMenu();
    }
}
