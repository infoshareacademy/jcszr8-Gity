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
                DateTime beginDate = default;
                DateTime endDate = default;

                if (DateTimeFormatter.TryParseStringYYYY_MM_DDTHH_MMToDateTime(item["begin_datetime"], out DateTime beginDateTime))
                {
                    beginDate = beginDateTime;
                }
                if (DateTimeFormatter.TryParseStringYYYY_MM_DDTHH_MMToDateTime(item["end_datetime"], out DateTime endDateTime))
                {
                    endDate = endDateTime;
                }

                this.rentals.Add(new Rental()
                {
                    Id = int.Parse(item["id"].Trim()),
                    CustomerId = int.Parse(item["customer_id"].Trim()),
                    CarId = int.Parse(item["car_id"].Trim()),
                    BeginDate = beginDate,
                    EndDate = endDate,
                    TotalCost = decimal.Parse(item["total_cost"].Trim()),
                });
            }
        }
    }
}
