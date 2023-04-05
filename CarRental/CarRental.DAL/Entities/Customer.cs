using CarRental.DAL.Entities.BaseEntity;
using CommonLibrary.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;

namespace CarRental.DAL.Entities;

public class Customer : Entity
{
    public Customer()
    {
        if (_genderHelper is not null)
        {
            if (_genderHelper.ToString().ToUpper() == "M")
                _gender = Gender.Male;
            else if (_genderHelper.ToString().ToUpper() == "F")
                _gender = Gender.Female;
            else if (_genderHelper.ToString().ToUpper() == "O")
                _gender = Gender.Other;
        }
        else throw new Exception("_gender is null !");
    }

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

    [MaxLength(10)]
    [JsonProperty("gender")]
    private string _genderHelper;

    private Gender _gender;

    //public Gender Gender { get; set; }

    public Gender Gender
    {
        get => _gender;
        set
        {
            _gender = value;
        }
    }


    private void SetUpGenderProperty()
    {

    }
}
