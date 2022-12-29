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

            //DataHelper.MigrateAllFromTsvToJson(); // migrates model data from TSV files to JSON files

            // Loading data on startup
            List<Car> cars = DataHelper.GetCars();
            List<Rental> rentals = DataHelper.GetRentals();
            List<Customer> customers = DataHelper.GetCustomers();

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