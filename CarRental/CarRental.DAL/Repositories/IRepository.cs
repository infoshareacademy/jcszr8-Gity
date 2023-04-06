using CarRental.DAL.Entities.BaseEntity;
using System.Linq.Expressions;

namespace CarRental.DAL.Repositories;

public interface IRepository<T> where T : Entity
{
    //List<T> GetAll();
    List<T> GetAll(Expression<Func<T, object>>? include = null);
    T Get(int id);
    void Insert(T entity);
    void Update(T entity);
    void Delete(int id);

    //void Delete(T entity);
}
