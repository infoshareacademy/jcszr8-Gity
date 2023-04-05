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

    [JsonProperty("email_address")]
    [EmailAddress]
    public string? EmailAddress { get; set; }

    [JsonProperty("phone_number")]
    public string PhoneNumber { get; set; }

    [MinLength(11)]
    [MaxLength(11)]
    [JsonProperty("pesel")]
    public string? Pesel { get; set; }

    private Gender _gender;

    [MaxLength(10)]
    [JsonProperty("gender")]
    public Gender Gender
    {
        get => _gender;
        set
        {
            if (value.ToString().ToUpper() == "M")
                _gender = Gender.Male;
            else if (value.ToString().ToUpper() == "F")
                _gender = Gender.Female;
            else if (value.ToString().ToUpper() == "O")
                _gender = Gender.Other;
        }
    }
}
