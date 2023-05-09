using CarRental.Common.Enums;
using Microsoft.AspNetCore.Identity;

namespace CarRental.DAL.Entities;

public class Customer : IdentityUser<int>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string? EmailAddress { get; set; }
    public string? Pesel { get; set; }
    public Gender Gender { get; set; }
    public virtual ICollection<Car> Cars { get; set; }
}
