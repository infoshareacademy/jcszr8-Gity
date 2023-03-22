using CarRental.DAL.Entities;

namespace CarRental.DAL.Context;

public static class Seed
{
    //private readonly IMapper _mapper;

    //public Seed(IMapper mapper)
    //{
    //    _mapper = mapper;
    //}

    public static void Initialize(ApplicationContext context)
    {
        context.Database.EnsureCreated();
        //var _mapper = new Mapper();
        Customer[] customers = CarRentalData.Customers.ToArray();
        Car[] cars = CarRentalData.Cars.ToArray();
        Rental[] rentals = CarRentalData.Rentals.ToArray();

        if (context.Customers.Any())
        {
            return; // DB has been seeded
        }

        foreach (var customer in customers)
        {
            context.Customers.Add(new()
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                PhoneNumber = customer.PhoneNumber,
                EmailAddress = customer.EmailAddress,
                Gender = customer.Gender,
                Pesel = customer.Pesel,
            });
        }
        var entriesNumber = context.SaveChanges();

        string temp = string.Empty;

        foreach (var car in cars)
        {
            var carDto = new Car().FillModel(car);
            context.Cars.Add(carDto);
        }
        context.SaveChanges();

        foreach (var rental in rentals)
        {
            context.Rentals.Add(rental);
        }
        context.SaveChanges();
    }
}