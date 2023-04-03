using CarRental.Logic.Models;

namespace CarRental.Logic.Services.IServices;

public interface ICustomerService
{
    IEnumerable<CustomerModel> GetAll();

    CustomerModel? Get(int id);

    void Create(CustomerModel model);

    void Create(string firstName, string lastName, string phoneNumber);

    void Update(CustomerModel customer);

    void Delete(int id);
}
