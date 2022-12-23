namespace CarRental.DAL.Models
{
    public sealed class Rental
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public int CarId { get; set; }

        public DateTime RentalStartDate { get; set; }

        public DateTime RentalEndDate { get; set; }
        public decimal RentalCost { get; set; } // in PLN
    }
}