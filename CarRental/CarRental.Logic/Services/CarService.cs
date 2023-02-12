using CarRental.DAL;
using CarRental.DAL.Models;

namespace CarRental.Logic.Services
{
    public class CarService
    {
        public List<Car> GetAll()
        {
            return CarRentalData.Cars;
        }
    }
}
