using AutoMapper;
using CarRental.DAL.Entities;
using CarRental.DAL.Repositories;
using CarRental.Logic.Models;
using CarRental.Logic.Services.IServices;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace CarRental.Logic.Services;

public class CustomerService : ICustomerService
{
    private readonly IRepository<Customer> _customerRepository;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;
    private readonly IValidator<CustomerViewModel> _validator;

    public CustomerService(IRepository<Customer> customerRepository, IMapper mapper, ILogger<CustomerService> logger, IValidator<CustomerViewModel> validator)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
        _logger = logger;
        _validator = validator ?? throw new ArgumentNullException(nameof(validator));
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
        ValidationResult results = _validator.Validate(model);

        if (!results.IsValid)
        {
            foreach (var failure in results.Errors)
            {
                _logger.LogInformation("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                Debug.WriteLine("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage); // TODO: remove when checked
            }
        }
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
        _logger.LogInformation($"Customer {model.FirstName} {model.LastName} was created.");
    }

    public void Update(CustomerViewModel model)
    {
        ValidationResult results = _validator.Validate(model);

        if (!results.IsValid)
        {
            foreach (var failure in results.Errors)
            {
                _logger.LogInformation("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                Debug.WriteLine("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage); // TODO: remove when checked
            }
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
