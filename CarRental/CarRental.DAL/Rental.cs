namespace CarRental.DAL
{
    public class Rental
    {
        public int CarId;
        public DateTime DateFrom;
        public DateTime DateTo;
        public string Status; //ex. rented, available, in_service
    }
}