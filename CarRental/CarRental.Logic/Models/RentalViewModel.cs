using System.ComponentModel.DataAnnotations;

namespace CarRental.Logic.Models;

public class RentalViewModel
{
    public int Id { get; set; }
    [Display(Name = "Customer Id")]
    public int CustomerId { get; set; }
    [Display(Name = "Car Id")]
    public int CarId { get; set; }
    [Display(Name = "Begin Date")]
    public DateTime BeginDate { get; set; }
    [Display(Name = "End Date")]
    public DateTime EndDate { get; set; }
    [Display(Name = "Total Cost")]
    public decimal? TotalCost { get; set; }
    [Display(Name = "Customer Name")]
    public string? CustomerName { get; set; }
    [Display(Name = "Car License Plate")]
    public string? CarLicencePlate { get; set; }
    public DateTime Created { get; set; }  //TODO remove from here
    public DateTime? Updated { get; set; } //TODO remove from here
    public List<object> Customers { get; set; } = new();
    public List<object> Cars { get; set; } = new();
}
