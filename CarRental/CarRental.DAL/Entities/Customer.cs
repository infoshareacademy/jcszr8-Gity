using CarRental.DAL.Entities.BaseEntity;
using CommonLibrary.Enums;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace CarRental.DAL.Entities;

public class Customer : Entity
{
    [JsonProperty("first_name")]
    public string FirstName { get; set; }

    [JsonProperty("last_name")]
    [MaxLength(30)]
    public string LastName { get; set; }

    [JsonProperty("phone_number")]
    public string PhoneNumber { get; set; }

    [JsonProperty("email_address")]
    [EmailAddress]
    public string? EmailAddress { get; set; }

    [MinLength(11)]
    [MaxLength(11)]
    [JsonProperty("pesel")]
    public string? Pesel { get; set; }

    [MaxLength(10)]
    [JsonProperty("gender")]
    public Gender Gender { get; set; }
}
