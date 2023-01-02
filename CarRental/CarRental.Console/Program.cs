using CarRental.DAL;

namespace CarRental.ConsoleUI;
internal class Program
{
    static void Main(string[] args)
    {
        Console.Title = AppConfig.APP_NAME;

        //DataMigrator.MigrateAllFromTsvToJson(); // migrates model data from TSV files to JSON files

        ConsoleMenu.Menu();
    }
}
