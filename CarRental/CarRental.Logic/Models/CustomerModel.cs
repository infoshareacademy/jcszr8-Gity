using CommonLibrary.Enums;
using System.ComponentModel.DataAnnotations;

namespace CarRental.Logic.Models;
public sealed class CustomerModel
{
    public int Id { get; set; }

    [Display(Name = "First Name")]
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? EmailAddress { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Pesel { get; set; }
    public Gender Gender { get; set; }
}
