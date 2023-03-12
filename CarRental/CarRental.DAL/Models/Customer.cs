using System.Text.Json.Serialization;
using System.Text;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace CarRental.DAL.Models;
public sealed class Customer
{
    [Range(0, 100, ErrorMessage = "Zwaliłeś sprawe!")]
    [JsonProperty("id")]
    public int Id;

    [JsonProperty("first_name")]
    public string FirstName { get; set; }

    [JsonProperty("last_name")]
    public string LastName { get; set; }

    [JsonProperty("email_address")]
    public string? EmailAddress { get; set; }

    [JsonProperty("phone_number")]
    public string PhoneNumber { get; set; }

    [JsonProperty("pesel")]
    public string? Pesel { get; set; }

    [JsonProperty("gender")]
    public char Gender { get; set; } // F female, M male, O other

    public Customer(int id, string firstName, string lastName, string phoneNumber)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        PhoneNumber = phoneNumber;
    }

    public Customer() { }

    public override string ToString()
    {
        return $"{FirstName} {LastName} {PhoneNumber}";
    }
}
