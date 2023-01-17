using Newtonsoft.Json;

namespace CarRental.DAL.Models;
public sealed class Customer
{
    public int Id;
    public Customer(string firstName, string lastName, string phoneNumber)
    {
        FirstName = firstName;
        LastName = lastName;
        PhoneNumber = phoneNumber;
    }

    [JsonProperty("first_name")]
    public string FirstName { get; set; } = string.Empty;

    [JsonProperty("last_name")]
    public string LastName { get; set; } = string.Empty;

    [JsonProperty("email_address")]
    public string? EmailAddress { get; set; }

    [JsonProperty("phone_number")]
    public string PhoneNumber { get; set; } = string.Empty;

    public string? Pesel { get; set; }

    [JsonProperty("date_of_birth")]
    public DateOnly? DateOfBirth { get; set; }

    public char Gender { get; set; } // F female, M male, O other

    [JsonProperty("postal_address")]
    public PostalAddress? PostalAddress { get; set; }

    public override string ToString()
    {
        return $"{FirstName} {LastName} {PhoneNumber}";
    }
}
