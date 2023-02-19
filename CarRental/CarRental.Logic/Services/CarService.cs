﻿using CarRental.DAL;
using CarRental.DAL.Models;

namespace CarRental.Logic.Services;

public interface ICarService
{
    List<Car> GetAll();
}

public class CarService : ICarService
{
    private int _idCounter = CarRentalData.Cars.Max(c => c.Id);

    public List<Car> GetAll()
    {
        return CarRentalData.Cars;
    }

    public Car GetById(int carId)
    {
        return CarRentalData.Cars.FirstOrDefault(c => c.Id == carId);
    }

    private int GetNextId()
    {
        return ++_idCounter;
    }
}
