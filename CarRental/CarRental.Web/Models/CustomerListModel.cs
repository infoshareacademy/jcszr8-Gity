using CarRental.DAL.Models;
using System.ComponentModel;

namespace CarRental.Web.Models;

public class CustomerListModel
{
    [DisplayName("Id.")]
    public int Id { get; set; }

    [DisplayName("First Name")]
    public string? FirstName { get; set; }

    [DisplayName("Last Name")]
    public string? LastName { get; set; }

    [DisplayName("Email Address")]
    public string? EmailAddress { get; set; }

    [DisplayName("Phone Number")]
    public string? PhoneNumber { get; set; }

    public string? Pesel { get; set; }

    public char Gender { get; set; }

    public CustomerListModel FillModel(Customer baseModel)
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
}