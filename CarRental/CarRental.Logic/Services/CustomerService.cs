using CarRental.DAL;
using CarRental.DAL.Models;

namespace CarRental.Logic.Services;

public class CustomerService : ICustomerService
{
    private static int _idCounter = CarRentalData.Customers.Max(c => c.Id);
    private List<Customer> _customers = CarRentalData.Customers;

    public List<Customer> GetAll()
    {
        return _customers;
    }

    public Customer? GetById(int customerId)
    {
        return CarRentalData.Customers.FirstOrDefault(c => c.Id == customerId);
    }

    public void Create(Customer customer)
    {
        customer.Id = GetNextId();
        CarRentalData.Customers.Add(customer);
    }

    private int GetNextId()
    {
        return ++_idCounter;
    }
}
