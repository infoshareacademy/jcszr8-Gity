using CarRental.DAL.Entities;
using CarRental.DAL.Repositories;
using CarRental.Logic.Models;
using CarRental.Logic.Services.IServices;

namespace CarRental.Logic.Services;

public class CustomerService : ICustomerService
{
    private readonly IRepository<Customer> _customerRepository;

    public CustomerService(IRepository<Customer> customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public IEnumerable<CustomerModel> GetAll()
    {
        return _customerRepository.GetAll();
    }

    public CustomerModel? Get(int customerId)
    {
        return _customerRepository.GetAll().FirstOrDefault(c => c.Id == customerId);
    }

    public void Create(CustomerModel customer)
    {
        customer.Id = GetNextId();
        _customerRepository.Insert(customer);
    }

    public void Create(string firstName, string lastName, string phoneNumber)
    {
        if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) 
            || string.IsNullOrEmpty(phoneNumber))
        {
            return;
        }

        _customerRepository.Insert(new CustomerModel
        {
            FirstName = firstName,
            LastName = lastName,
            PhoneNumber = phoneNumber
        });
    }

    public void Update(CustomerModel model)
    {
        _customerRepository.Update(model);
    }

    public void Delete(int customerId) {

        var customer = _customerRepository.Get(customerId);
        _customerRepository.Delete(customer);
    }  

    private int GetNextId() => ++_idCounter;  // TODO GenNextId()

    IEnumerable<CustomerModel> ICustomerService.GetAll()
    {
        throw new NotImplementedException();
    }

    CustomerModel? ICustomerService.Get(int id)
    {
        throw new NotImplementedException();
    }

    public void Create(CustomerModel customer)
    {
        throw new NotImplementedException();
    }

    public void Update(CustomerModel customer)
    {
        throw new NotImplementedException();
    }
}
