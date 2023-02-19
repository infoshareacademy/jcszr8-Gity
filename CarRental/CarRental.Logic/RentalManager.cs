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
        private static int _idCounter = CarRentalData.Rentals.Max(r => r.Id);

        private static List<Rental> _rentals = CarRentalData.Rentals;

        public static Rental GetById(int rentalId)
        {
            return _rentals.FirstOrDefault(r => r.Id == rentalId);
        }

        private static int GetNextId()
        {
            return ++_idCounter;
        }
        //public static List<Rental> GetAll()
        //{
        //    return _rentals;
        //}
        public static string RentalsToTableString()
        {
            StringBuilder sb = new();
            sb.Append(String.Format("\n{0,4}.| {1,-20}| {2,-25}| {3,-10}\n", "Id", "Make", "Model", "License plate"));
            sb.Append(new String('-', sb.Length));
            sb.Append('\n');
            foreach (var rental in _rentals)
            {
                sb.Append($"{car.Id,4}.| {car.Make,-20}| {car.CarModel,-25}| {car.LicencePlateNumber,-10}{Environment.NewLine}");
            }
            return sb.ToString();
        }
    }   
}
