using CarRental.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarRental.DAL.Context;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
        
    }

    public DbSet<Customer> Customers { get; set; }

    public DbSet<Car> Cars { get; set; }

    public DbSet<Rental> Rentals { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(b => b.MigrationsAssembly("CarRental.Web"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>()
            .HasMany<Rental>()
            .WithOne();
        
        modelBuilder.Entity<Car>()
            .HasMany<Rental>()
            .WithOne();
        // Car - one2many - Rental; Customer - one2many - Rental


        base.OnModelCreating(modelBuilder);

        //modelBuilder.Entity<Customer>();  // ?????
    }
}
