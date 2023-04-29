using System.ComponentModel.DataAnnotations;

namespace CarRental.Web.Models;

public class Term // TODO - refactor
{
    [Display(Name = "Date From")]
    public string? DateFrom { get; set; }

    [Display(Name = "Date To")]
    public string? DateTo { get; set; }
}
