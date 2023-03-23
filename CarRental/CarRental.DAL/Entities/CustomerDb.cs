using System.Net.Sockets;

namespace CarRental.DAL.Entities;
public class CustomerDb
{
    public int Id { get; set; }
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string? EmailAddress { get; set; }

    public string PhoneNumber { get; set; }

    public string? Pesel { get; set; }

    public char? Gender { get; set; }
}


public class CustomerDbBuilder
{
    private CustomerDb cdb;

    public CustomerDbBuilder()
    {
        cdb = new CustomerDb();
    }

    public static CustomerDbBuilder aCustomerDb()
    {
        return new CustomerDbBuilder();
    }

    public CustomerDbBuilder WithFirstName(string firstName)
    {
        cdb.FirstName = firstName; 
        return this;
    }

    public CustomerDbBuilder WithLastName(string lastName)
    {
        cdb.LastName = lastName;
        return this;
    }

    public CustomerDbBuilder WithPhoneNumber(string phoneNumber)
    {
        cdb.PhoneNumber = phoneNumber;
        return this;
    }




    public CustomerDb Build()
    {
        return cdb;
    }
}
