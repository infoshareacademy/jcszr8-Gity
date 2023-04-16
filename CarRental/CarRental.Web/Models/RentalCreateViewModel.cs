namespace CarRental.Web.Models;

public class RentalCreateViewModel
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int CarId { get; set; }
    public DateTime BeginDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal TotalCost { get; set; }

    public List<object> Customers { get; set; } = new();
    public List<object> Cars { get; set; } = new();
}
