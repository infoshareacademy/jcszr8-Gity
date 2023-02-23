using CarRental.DAL;
using CarRental.DAL.Models;

namespace CarRental.Logic.Services;

public class CustomerService : ICustomerService
{
    public List<Customer> GetAll()
    {
        return CarRentalData.Customers;
    }

    public Customer? GetById(int customerId)
    {
        return CarRentalData.Customers.FirstOrDefault(c => c.Id == customerId);
    }
}
