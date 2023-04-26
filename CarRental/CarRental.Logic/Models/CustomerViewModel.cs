using CarRental.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace CarRental.Logic.Models;
public sealed class CustomerViewModel
{
    public int Id { get; set; }

    [Display(Name = "First Name")]
    [Required]
    public string? FirstName { get; set; }

    [Display(Name = "Last Name")]
    [Required]
    public string? LastName { get; set; }
    [Display(Name = "Phone Number")]
    [Required]
    public string? PhoneNumber { get; set; }
    
    [Display(Name = "Email adress")]
    [EmailAddress]
    public string? EmailAddress { get; set; }

    [RegularExpression(@"^\d{11}$")]
    [MinLength(11)]
    [MaxLength(11)]
    public string? Pesel { get; set; }

    [Required]
    public Gender Gender { get; set; }
}
