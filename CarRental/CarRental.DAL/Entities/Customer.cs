using CarRental.Common.Enums;
using CarRental.DAL.Entities.BaseEntity;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace CarRental.DAL.Entities;

public class Customer : Entity
{
    [JsonProperty("first_name")]
    public string FirstName { get; set; }

    [JsonProperty("last_name")]
    public string LastName { get; set; }

    [JsonProperty("phone_number")]
    public string PhoneNumber { get; set; }

    [JsonProperty("email_address")]
    public string? EmailAddress { get; set; }

    [JsonProperty("pesel")]
    public string? Pesel { get; set; }

    [JsonProperty("gender")]
    public Gender Gender { get; set; }
}
