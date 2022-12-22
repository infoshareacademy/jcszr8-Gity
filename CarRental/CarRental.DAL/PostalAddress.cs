using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.DAL
{
    public sealed class PostalAddress
    {
        public string Street { get; set; } = String.Empty;
        public string BuildingNo { get; set; } = String.Empty;
        public string ApartmentNo { get; set; } = String.Empty;
        public string ZipCode { get; set; } = String.Empty;
        public string City { get; set; } = String.Empty;
        public string Country { get; set; } = "Polska";
    }
}
