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
        // required for Car: make, model, license plate, year
        modelBuilder.Entity<Car>(eb =>
        {
            eb.Property(c => c.CarModelProp).IsRequired();
            eb.Property(c => c.Make).IsRequired().HasMaxLength(100);
            eb.Property(c => c.LicencePlateNumber).IsRequired().HasMaxLength(8);
            eb.Property(c => c.Year).IsRequired();
            eb.Property(c => c.Color).HasMaxLength(30);
            eb.Property(c => c.Transmission).HasMaxLength(20);
            eb.Property(c => c.Displacement).HasMaxLength(20);
            eb.Property(c => c.FuelConsumption).HasMaxLength(5);

        });

        base.OnModelCreating(modelBuilder);

        //modelBuilder.Entity<Customer>();  // ?????
    }
}
