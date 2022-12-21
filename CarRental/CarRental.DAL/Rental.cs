namespace CarRental.DAL
{
    public class Rental
    {
        public int CarId;

        public DateTime RentalStartDate;

        public DateTime RentalEndDate;
        public decimal RentalCost { get; set; } // in PLN
    }
}