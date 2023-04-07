namespace CarRental.Logic.Models;
public class RentalDto
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int CarId { get; set; }
    public DateTime BeginDate { get; set; }
    public DateTime EndDate {  get; set; }
    public decimal TotalCost { get; set; }
}
