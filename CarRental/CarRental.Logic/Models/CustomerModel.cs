using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace CarRental.Logic.Models;
public sealed class CustomerModel
{
    //public CustomerModel() { }

    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string? EmailAddress { get; set; }

    public string PhoneNumber { get; set; }

    public string? Pesel { get; set; }

    public char? Gender { get; set; }
}
