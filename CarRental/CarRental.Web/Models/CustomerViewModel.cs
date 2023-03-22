using System.ComponentModel;

namespace CarRental.Web.Models;

public class CustomerViewModel
{
    [DisplayName("Id.")]
    public int Id { get; set; }

    [DisplayName("First Name")]
    public string FirstName { get; set; }

    [DisplayName("Last Name")]
    public string LastName { get; set; }

    [DisplayName("Email Address")]
    public string? EmailAddress { get; set; }

    [DisplayName("Phone Number")]
    public string PhoneNumber { get; set; }

    public string? Pesel { get; set; }

    public char? Gender { get; set; }
}
