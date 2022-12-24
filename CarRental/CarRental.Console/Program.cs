using CarRental.ConsoleUI.Utils;
using CarRental.DAL;
using CarRental.DAL.Models;
using CarRental.DAL.Utilities;

namespace CarRental.ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Cud Auta";
            ConsoleMenu.Menu();

            // DataHelper.MigrateAll(); // migrates model data from TSV files to JSON files
        }
        public static void PrintCarList(List<Car> cars)
        {
            Console.WriteLine($"Number of cars in database: {cars.Count}");
            foreach (Car car in cars)
            {
                //Console.WriteLine(car.Model);
                car.GetDetails();
            }
        }
    }
}