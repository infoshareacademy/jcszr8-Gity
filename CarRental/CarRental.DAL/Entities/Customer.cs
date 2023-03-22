namespace CarRental.DAL.Entities;

public class Customer
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string? EmailAddress { get; set; }

    public string PhoneNumber { get; set; }

    public string? Pesel { get; set; }

    public char? Gender { get; set; }
}
