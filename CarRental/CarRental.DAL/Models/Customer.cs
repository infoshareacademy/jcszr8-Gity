using System.Text.Json.Serialization;


namespace CarRental.DAL.Models;
public sealed class Customer
{
    [JsonPropertyName("id")]
    public int Id;

    [JsonPropertyName("first_name")]
    public string FirstName { get; set; } = string.Empty;

    [JsonPropertyName("last_name")]
    public string LastName { get; set; } = string.Empty;

    [JsonPropertyName("email_address")]
    public string? EmailAddress { get; set; }

    [JsonPropertyName("phone_number")]
    public string PhoneNumber { get; set; } = string.Empty;

    [JsonPropertyName("pesel")]
    public string? Pesel { get; set; }

    [JsonPropertyName("gender")]
    public char Gender { get; set; } // F female, M male, O other

    [JsonPropertyName("postal_address")]
    public string? PostalAddress { get; set; }

    public Customer(int id, string firstName, string lastName, string phoneNumber)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        PhoneNumber = phoneNumber;
    }

    public override string ToString()
    {
        return $"{FirstName} {LastName} {PhoneNumber}";
    }
}
