using CarRental.DAL.Models;
using CarRental.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Logic
{
    public class RentalManager
    {
        private static readonly int _idCounter = CarRentalData.Rentals.Max(r => r.Id);

        private static List<Rental> _rentals = CarRentalData.Rentals;
        
        public static Rental GetById(int rentalId)
        {
            return _rentals.FirstOrDefault(r => r.Id == rentalId);
        }

        //private static int GetNextId()
        //{
        //    return ++_idCounter;
        //}

    }
   
}
