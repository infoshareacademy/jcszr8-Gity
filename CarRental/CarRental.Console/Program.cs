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
            DateTime dt = DateTime.Now;
            Console.WriteLine(dt);
            Console.ReadKey();
            DataHelper.MigrateAll(); // migrates model data from TSV files to JSON files
            ConsoleMenu.Menu();

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