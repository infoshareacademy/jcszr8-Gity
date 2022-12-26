using CarRental.ConsoleUI.Utils;
using CarRental.DAL.Models;
using System;

namespace CarRental.DAL.Utilities
{
    public sealed class CustomersTSVFileReader : TSVFileReader
    {
        public static string TSV_FILE_NAME = "customers.tsv";

        public List<Customer> customers = new();

        public override void LoadItems()
        {
            foreach (var item in this.elements)
            {
                var firstName = item["first_name"].Trim();
                var lastName = item["last_name"].Trim();
                var phoneNumber = item["phone_number"].Trim();

                bool parsed = DateTimeFormatter.TryParseDateStringYYYY_MM_DDToDateOnly(item["date_of_birth"].Trim(), out DateOnly dateOnly);
              

                this.customers.Add(new Customer(firstName, lastName, phoneNumber)
                {
                    Id = int.Parse(item["id"]),
                    EmailAddress = item["email_address"].Trim(),
                    Gender = char.Parse(item["gender"].Trim()),
                    Pesel = item["pesel"].Trim(),
                    DateOfBirth = parsed ? dateOnly : null,
                    //PostalAddress = new PostalAddress()
                    //{
                    //    Country = item["country"].Trim(),
                    //    City = item["city"].Trim(),
                    //    ZipCode = item["zip_code"].Trim(),
                    //    Street = item["street"].Trim(),
                    //    BuildingNo = item["building_number"].Trim(),
                    //    ApartmentNo = item["apartment_number"].Trim(),
                    //}
                });
            }
        }
    }
}
