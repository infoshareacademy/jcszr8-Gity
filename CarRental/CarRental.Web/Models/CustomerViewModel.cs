using CarRental.DAL.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;

namespace CarRental.Web.Models;

public class CustomerViewModel
{
    [DisplayName("Id.")]
    public int Id { get; set; }

    [DisplayName("First Name")]
    public string FirstName { get; set; }

    [DisplayName("Last Name")]
    public string LastName { get; set; }

    [DisplayName("Email Address")]
    public string? EmailAddress { get; set; }

    [DisplayName("Phone Number")]
    public string PhoneNumber { get; set; }

    public string? Pesel { get; set; }

    public char? Gender { get; set; }

    public CustomerViewModel FillModel(Customer baseModel)
    {
        this.Id = baseModel.Id;
        this.FirstName = baseModel.FirstName;
        this.LastName = baseModel.LastName;
        this.EmailAddress = baseModel.EmailAddress;
        this.PhoneNumber = baseModel.PhoneNumber;
        this.Pesel = baseModel.Pesel;
        this.Gender = baseModel.Gender;

        return this;
    }

    public Customer FillEntity()
    {
        var customer = new Customer
        {
            Id = this.Id,
            FirstName = this.FirstName,
            LastName = this.LastName,
            EmailAddress = this.EmailAddress,
            PhoneNumber = this.PhoneNumber,
            Pesel = this.Pesel,
            Gender = this.Gender
        };

        return customer;
    }
}
