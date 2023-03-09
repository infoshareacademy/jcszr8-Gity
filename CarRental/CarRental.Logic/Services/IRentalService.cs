using CarRental.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Logic.Services
{
    public interface IRentalService
    {
        List<int> GetAvailableCarIds(DateTime start, DateTime end);
        List<Car> ListOfAvailableCarForRent(List<int> carIds);
        List<int> GetNotRented();
        List<int> GetAvailableInGivenTime(DateTime start, DateTime end);
    }
}
