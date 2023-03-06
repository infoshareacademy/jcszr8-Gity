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

    private int GetNextId()
    {
        return ++_idCounter;
    }
}
