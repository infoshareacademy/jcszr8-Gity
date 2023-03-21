﻿using CarRental.DAL.Context;
using CarRental.DAL.Entities.BaseEntity;
using Microsoft.EntityFrameworkCore;

namespace CarRental.DAL.Repositories;

public class Repository<T> : IRepository<T> where T : BaseEntity
{
    private readonly ApplicationContext _context;
    private readonly DbSet<T> _entities;

    public Repository(ApplicationContext context)
    {
        _context = context;
        _entities = context.Set<T>();
    }

    public List<T> GetAll()
    {
        // TODO AsAsyncEnumerable()
        return this._entities.AsEnumerable().ToList();
    }

    public T Get(int id)
    {
        // TODO SingleOrDefaultAsync
        return this._entities.SingleOrDefault(e => e.Id == id)!;
    }

    public void Insert(T entity)
    {
        if (entity is null)
        {
            return; // or throw exception - incorrect usage
        }
        this._entities.Add(entity);
        this._context.SaveChanges();
    }

    public void Update(T entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(T entity)
    {
        throw new NotImplementedException();
    }
}