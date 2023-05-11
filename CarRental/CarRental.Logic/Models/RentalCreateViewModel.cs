
using System.ComponentModel.DataAnnotations;

namespace CarRental.Logic.Models;


public class RentalCreateViewModel
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int CarId { get; set; }
    [Display(Name = "Begin Date")]
    public DateTime BeginDate { get; set; }
    [Display(Name = "End Date")]
    public DateTime EndDate { get; set; }
    [Display(Name = "Total Cost")]
    public decimal TotalCost { get; set; }
    public List<object> Customers { get; set; } = new();
    public List<object> Cars { get; set; } = new();
}
