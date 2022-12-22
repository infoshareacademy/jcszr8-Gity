using CarRental.DAL;
using CarRental.DAL.Utilities;

namespace CarRental.ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {

            DataReaderAndWriter.WriteCarsToJson();

            List<Car> cars = DataReaderAndWriter.GetCarsFromJson();
            //Console.WriteLine($"Number of cars in database: {cars.Count}");
            //foreach (Car car in cars)
            //{
            //    Console.WriteLine(car.Model);
            //}
            Console.Title = "Cud Auta";
            ConsoleMenu.Menu();

        }
    }
}