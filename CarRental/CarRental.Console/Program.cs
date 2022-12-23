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
            //ConsoleMenu.Menu();

            var carReader = new CarsTSVFileReader();
            carReader.ReadTsv();
            carReader.LoadItems();
            List<Car> cars = carReader.cars;

            string carsSerialized = CarSerializerDeserializer.Serialize(cars);
            CarSerializerDeserializer.WriteToJsonFile(carsSerialized);

            Console.WriteLine($"Number of cars in database: {cars.Count}");
            foreach (Car car in cars)
            {
                Console.WriteLine(car.ToString());
            }
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