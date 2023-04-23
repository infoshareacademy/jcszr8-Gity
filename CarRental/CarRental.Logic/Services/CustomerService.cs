using AutoMapper;
using CarRental.DAL.Entities;
using CarRental.DAL.Repositories;
using CarRental.Logic.Models;
using CarRental.Logic.Services.IServices;

namespace CarRental.Logic.Services;

public class CustomerService : ICustomerService
{
    private readonly IRepository<Customer> _customerRepository;
    private readonly IMapper _mapper;

    public CustomerService(IRepository<Customer> customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    public IEnumerable<CustomerViewModel> GetAll()
    {
        var customers = _customerRepository.GetAll();
        return _mapper.Map<List<CustomerViewModel>>(customers);
    }

    public CustomerViewModel? Get(int customerId)
    {
        var customer = _customerRepository.Get(customerId);
        return _mapper.Map<CustomerViewModel>(customer);
    }

    public void Create(CustomerViewModel model)
    {
        _customerRepository.Insert(_mapper.Map<Customer>(model));
    }

    public void Create(string firstName, string lastName, string phoneNumber)
    {
        if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName)
            || string.IsNullOrEmpty(phoneNumber))
        {
            return;
        }

        var model = new CustomerViewModel
        {
            FirstName = firstName,
            LastName = lastName,
            PhoneNumber = phoneNumber
        };

        _customerRepository.Insert(_mapper.Map<Customer>(model));
    }

    public void Update(CustomerViewModel model)
    {
        var customer = _mapper.Map<Customer>(model);
        _customerRepository.Update(customer);
    }

    public void Delete(int id)
    {
        _customerRepository.Delete(id);
    }
}
