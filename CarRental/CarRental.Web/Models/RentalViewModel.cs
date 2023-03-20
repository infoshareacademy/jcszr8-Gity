using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CarRental.Web.Models;

public class RentalViewModel
{
    [DisplayName("Rental Id.")]
    public int Id { get; set; }

    [Display(Name = "Customer Id")]
    public int CustomerId { get; set; }

    [Display(Name = "Car Id")]
    public int CarId { get; set; }

    [Display(Name = "Start of Rental")]
    public DateTime BeginDate { get; set; }

    [Display(Name = "End of Rental")]
    public DateTime EndDate { get; set; }

    [Display(Name = "Total Cost")]
    public decimal? TotalCost { get; set; }
}
