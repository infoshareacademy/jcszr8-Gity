using CarRental.DAL.Models;

namespace CarRental.Logic;

public interface ICustomerManager
{
    List<CustomerModel> GetAll();

    CustomerModel GetById(int id);

    CustomerModel Create(CustomerModel customer);

    CustomerModel Update(CustomerModel customer);

    CustomerModel DeleteById(int id);

    void Add(CustomerModel customer);
}
