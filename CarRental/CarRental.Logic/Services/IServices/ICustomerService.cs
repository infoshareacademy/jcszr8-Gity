using CarRental.Logic.Models;

namespace CarRental.Logic.Services.IServices;

public interface ICustomerService
{
    IEnumerable<CustomerDto> GetAll();

    CustomerDto? Get(int id);

    void Create(CustomerDto model);

    void Create(string firstName, string lastName, string phoneNumber);

    void Update(CustomerDto customer);

    void Delete(int id);
}
