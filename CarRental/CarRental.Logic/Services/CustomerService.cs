using CarRental.DAL;
using CarRental.DAL.Models;
using CarRental.Logic.Interfaces;

namespace CarRental.Logic.Services;

public class CustomerService : ICustomerService
{
    private static int _idCounter;
    private List<Customer> _customers = CarRentalData.Customers;

    public CustomerService()
    {
        _idCounter = CarRentalData.Customers.Max(c => c.Id);
    }

    public IEnumerable<Customer> GetAll()
    {
        return _customers;
    }

    public Customer? GetById(int customerId)
    {
        return _customers.FirstOrDefault(c => c.Id == customerId);
    }

    public void Create(Customer customer)
    {
        customer.Id = GetNextId();
        _customers.Add(customer);
    }

    public void Update(Customer model)
    {
        var customer = GetById(model.Id);

        customer.FirstName = model.FirstName;
        customer.LastName = model.LastName;
        customer.PhoneNumber = model.PhoneNumber;
        customer.EmailAddress = model.EmailAddress;
        customer.Pesel =  model.Pesel;
        customer.Gender = model.Gender;
    }

    public void Delete(int customerId) {
        var customer = GetById(customerId);
        _customers.Remove(customer);
    }  

    private int GetNextId() => ++_idCounter;
}
