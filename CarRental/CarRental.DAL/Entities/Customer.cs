using CarRental.DAL.Entities.BaseEntity;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace CarRental.DAL.Entities;

public class Customer : Entity
{
    [JsonProperty("first_name")]
    [Display(Name = "First Name")]
    [MaxLength(30)]
    [Required]
    public string FirstName { get; set; }

    [JsonProperty("last_name")]
    [Display(Name = "Last Name")]
    [MaxLength(30)]
    [Required]
    public string LastName { get; set; }

    [JsonProperty("email_address")]
    [Display(Name = "Email")]
    [EmailAddress]
    [MaxLength(50)]
    public string? EmailAddress { get; set; }

    [JsonProperty("phone_number")]
    [Display(Name = "Phone Number")]
    [Phone]
    [Required]
    public string PhoneNumber { get; set; }

    [MinLength(11)]
    [MaxLength(11)]
    [JsonProperty("pesel")]
    public string? Pesel { get; set; }

    [MaxLength(10)]
    [JsonProperty("gender")]
    public char? Gender { get; set; }
}
