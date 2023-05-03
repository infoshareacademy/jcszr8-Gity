using AutoMapper;
using CarRental.DAL.Entities;
using CarRental.DAL.Repositories;
using CarRental.Logic.Models;
using CarRental.Logic.Services.IServices;
using Microsoft.Extensions.Logging;

namespace CarRental.Logic.Services;

public class CustomerService : ICustomerService
{
    private readonly IRepository<Customer> _customerRepository;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;
    private readonly ICustomerValidationService _validator;

    public CustomerService(IRepository<Customer> customerRepository, IMapper mapper, ILogger<CustomerService> logger,
        ICustomerValidationService validator)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
        _logger = logger;
        _validator = validator;
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
        if (!_validator.IsAllValid(model))
        {

        }
        _customerRepository.Insert(_mapper.Map<Customer>(model));
        _logger.LogInformation($"Customer {model.FirstName} {model.LastName} was created.");
    }

    public void Update(CustomerViewModel model)
    {
        if (!_validator.IsAllValid(model))
        {
            throw new ArgumentException("Customer is not valid.");
        }

        var customer = _mapper.Map<Customer>(model);
        _customerRepository.Update(customer);
        _logger.LogInformation($"Customer with id {model.Id} was updated.");
    }

    public void Delete(int id)
    {
        _customerRepository.Delete(id);
        _logger.LogInformation($"Customer with id {id} was deleted.");
    }
}
