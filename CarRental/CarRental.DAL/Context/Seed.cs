using CarRental.DAL.Entities;

namespace CarRental.DAL.Context;

public static class Seed
{
    public static void Initialize(ApplicationContext context)
    {
        context.Database.EnsureCreated();

        CarRentalData carRentalData = new CarRentalData();

        //var _mapper = new Mapper();
        Customer[] customers = CarRentalData.Customers.ToArray();
        Rental[] rentals = CarRentalData.Rentals.ToArray();

        //List<Car> cars;
        //try
        //{
        //    List<Car>cars = CarRentalData.Cars;
        //}
        //catch (Exception)
        //{

        //    throw new Exception("------- CarRentalData.Cars failed to load!");
        //}

        //Car[] carsArray = cars.ToArray();

        if (context.Customers.Any() && context.Rentals.Any())
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
            //context.Customers.Add(customer);
        }
        var entriesNumber = context.SaveChanges();

        string temp = string.Empty;

        //foreach (var car in cars)
        //{
        //    var carDto = new Car().FillModel(car);
        //    context.Cars.Add(carDto);
        //}
        //context.SaveChanges();

        foreach (var rental in rentals)
        {
            context.Rentals.Add(new Rental
            {
                Id = rental.Id,
                CarId = rental.CarId,
                CustomerId = rental.CustomerId,
                BeginDate = rental.BeginDate,
                EndDate = rental.EndDate,
                TotalCost = rental.TotalCost,
            });
            //context.Rentals.Add(rental);
        }
        context.SaveChanges();
    }
}
