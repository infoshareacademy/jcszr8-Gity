using CarRental.DAL.Enums;
using CarRental.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.DAL.Utilities
{
    public sealed class RentalsTSVFileReader : TSVFileReader
    {
        public static string TSV_FILE_NAME = "rental.tsv";
        public List<Rental> rentals = new();

        public override void LoadItems()
        {
            foreach (var item in this.elements)
            {
                this.rentals.Add(new Rental()
                {
                    Id = int.Parse(item["id"].Trim()),
                    CustomerId = int.Parse(item["customer_id"].Trim()),
                    CarId = int.Parse(item["car_id"].Trim()),
                    //BeginDate
                    //EndDate
                    TotalCost = decimal.Parse(item["total_cost"].Trim()),
                });
            }
        }
    }
}
