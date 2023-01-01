namespace CarRental.ConsoleUI;
internal class Program
{
    static void Main(string[] args)
    {
        Console.Title = AppConfig.APP_NAME;

        //DataHelper.MigrateAllFromTsvToJson(); // migrates model data from TSV files to JSON files

        ConsoleMenu.Menu();
    }
}
