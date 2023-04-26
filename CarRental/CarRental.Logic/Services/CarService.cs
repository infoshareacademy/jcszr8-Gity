using AutoMapper;
using CarRental.DAL.Entities;
using CarRental.DAL.Repositories;
using CarRental.Logic.Models;
using CarRental.Logic.Services.IServices;
using System.Text;

namespace CarRental.Logic.Services;

public class CarService : ICarService
{
    private readonly IRepository<Car> _carRepository;
    private readonly IMapper _mapper;

    public CarService(IRepository<Car> carRepository, IMapper mapper)
    {
        _carRepository = carRepository;
        _mapper = mapper;
    }

    public IEnumerable<CarViewModel> GetAll()
    {
        List<Car> cars = _carRepository.GetAll() ?? new List<Car>();
        var result = _mapper.Map<List<CarViewModel>>(cars);
        return result;
    }

    public IEnumerable<CarViewModel> GetByName(string name)
    {
        List<CarViewModel> cars = new();
        if (string.IsNullOrEmpty(name))
        {
            cars = GetAll().ToList();
        }
        else
        {
            var temp = _carRepository.GetAll()
                 .Where(c => c.Make.Contains(name, StringComparison.CurrentCultureIgnoreCase)
                 || c.CarModelProp.Contains(name, StringComparison.CurrentCultureIgnoreCase)
             ).ToList();

            cars = _mapper.Map<List<CarViewModel>>(temp);
        }
        return cars;
    }
    
    public List<CarViewModel> GetByYear(string read)
    {
        int year;
        bool makes = int.TryParse(read, out year);
        List<CarViewModel> cars = new();
        if (read == null)
        {
            cars = GetAll().ToList();
        }
        else
        {
            cars = GetAll().Where(c => c.Year == year || c.CarModelProp.ToLower().Contains(read.ToLower())).ToList();
        }
        return cars;
    }

    public void Create(CarViewModel model)
    {
        var car = _mapper.Map<Car>(model);
        _carRepository.Insert(car);
    }

    public CarViewModel? Get(int id)
    {
        var car = _carRepository.Get(id);

        if (car == null)
        {
            throw new Exception("Invalid ID");
        }
        return _mapper.Map<CarViewModel>(car);
    }

    public void Delete(int id)
    {
        _carRepository.Delete(id);
    }

    public void Update(CarViewModel model)
    {
        var car = _mapper.Map<Car>(model);

        _carRepository.Update(car);
    }
}
