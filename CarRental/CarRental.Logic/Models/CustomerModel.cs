using CommonLibrary.Enums;
using System.ComponentModel.DataAnnotations;

namespace CarRental.Logic.Models;
public sealed class CustomerModel
{
    public int Id { get; set; }

    [Display(Name = "First Name")]
    [Required]
    public string? FirstName { get; set; }
    [Required]
    public string? LastName { get; set; }
    [Required]
    public string? PhoneNumber { get; set; }

    [EmailAddress]
    public string? EmailAddress { get; set; }

    [RegularExpression(@"^\d{11}$")]
    [MinLength(11)]
    [MaxLength(11)]
    public string? Pesel { get; set; }

    [Required]
    public Gender Gender { get; set; }
}
