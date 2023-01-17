﻿using CarRental.DAL;
using CarRental.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Logic
{
    public class LogicSearch
    {
        public static List<Car> CarByMake(string make)
        {
            List<Car> cars = new List<Car>();
            if (string.IsNullOrEmpty(make))
            {
                cars = CarRentalData.Cars;
            }
            else
            {
                cars = CarRentalData.Cars.Where(c => c.Make?.ToLower() == make.ToLower() || 
                                                     c.Model?.ToLower() == make.ToLower()).ToList();

            }
            return cars;
        }
    }
}
