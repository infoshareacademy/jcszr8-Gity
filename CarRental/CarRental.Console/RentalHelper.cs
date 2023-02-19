using CarRental.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.ConsoleUI
{
    internal class RentalHelper
    {
        public static string RentalsToString()
        {
            var rentals = RentalManager.GetAll();
            StringBuilder sb = new StringBuilder();

            foreach (var rental in rentals)
            {
                sb.Append($"{rental.Id} {rental.CarId} {rental.BeginDate} {rental.EndDate}");
                sb.Append(Environment.NewLine);
            }
            return sb.ToString();
        }
    }
}
