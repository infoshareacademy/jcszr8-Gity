using AutoMapper;
using CarRental.DAL.Entities;
using CarRental.Logic.Models;
using CarRental.Logic.Services.IServices;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace CarRental.Logic.Services;

public class CustomerService : ICustomerService
{
    private readonly IMapper _mapper;
    private readonly ILogger _logger;
    private readonly IValidator<CustomerViewModel> _validator;
    private readonly UserManager<Customer> _userManager;
    private readonly RoleManager<IdentityRole<int>> roleManager;


    public CustomerService(IMapper mapper, ILogger<CustomerService> logger,
        IValidator<CustomerViewModel> validator, UserManager<Customer> userManager)
    {
        _mapper = mapper;
        _logger = logger;
        _validator = validator;
        _userManager = userManager;
    }

    public IEnumerable<CustomerViewModel> GetAll()
    {
        //var temp = _userManager.GetUsersInRoleAsync();
        //var customers = _customerRepository.GetAll();
        //return _mapper.Map<List<CustomerViewModel>>(customers);

        var customers = _userManager.Users.ToList();
        var model = _mapper.Map<List<CustomerViewModel>>(customers);
        return model;
    }

    public CustomerViewModel? Get(int customerId)
    {
        var customer = _userManager.Users.FirstOrDefault(c => c.Id == customerId);
        return _mapper.Map<CustomerViewModel>(customer);
    }

    public async Task CreateAsync(CustomerViewModel model)
    {
        if (!IsAllValid(model))
        {
            throw new ArgumentException("Customer is not valid.");
        }
        var newCustomer = _mapper.Map<Customer>(model);
        var result = await _userManager.CreateAsync(newCustomer); // TODO password creation
        if (result.Succeeded)
        {
            await _userManager.AddPasswordAsync(newCustomer, "Pa$$w0rd");
            await _userManager.AddToRoleAsync(newCustomer, "Member");
        }
        _logger.LogInformation($"Customer {model.FirstName} {model.LastName} was created.");
    }

    public void Update(CustomerViewModel model)
    {
        //if (!IsAllValid(model))
        //{
        //    throw new ArgumentException("Customer is not valid.");
        //}
        //var customer = _mapper.Map<Customer>(model);
        //_customerRepository.Update(customer);
        //_logger.LogInformation($"Customer with id {model.Id} was updated.");

        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        //_customerRepository.Delete(id);
        //_logger.LogInformation($"Customer with id {id} was deleted.");

        throw new NotImplementedException();
    }

    #region Validation
    public bool IsAllValid(CustomerViewModel customer)
    {
        var validationResult = _validator.Validate(customer);
        LogErrors(validationResult);
        return validationResult.IsValid;
    }

    private void LogErrors(ValidationResult validationResult)
    {
        foreach (var failure in validationResult.Errors)
        {
            _logger.LogInformation("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
        }
    }
    #endregion Validation
}
