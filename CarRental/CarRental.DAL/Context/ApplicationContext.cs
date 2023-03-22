using CarRental.DAL.Entities.BaseEntity;
using CarRental.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRental.DAL.Context;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
        
    }

    public DbSet<CustomerModel> Customers { get; set; }

    public DbSet<Car> Cars { get; set; }

    public DbSet<RentalModel> Rentals { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //modelBuilder.Entity<Customer>();  // ?????
    }
}
