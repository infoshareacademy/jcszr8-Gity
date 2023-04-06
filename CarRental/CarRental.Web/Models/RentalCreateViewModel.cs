namespace CarRental.Web.Models;

public class RentalCreateViewModel
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int CarId { get; set; }
    public DateTime BeginDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal? TotalCost { get; set; }

    public string? CustomerName { get; set; }
    public string? CarLicencePlate { get; set; }

    public string? CarMake { get; set;}
    public string? CarModel { get; set;}
}
