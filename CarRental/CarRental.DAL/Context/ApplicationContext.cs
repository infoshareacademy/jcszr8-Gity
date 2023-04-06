using CarRental.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarRental.DAL.Context;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
    }

    public DbSet<Customer>? Customers { get; set; }
    public DbSet<Car>? Cars { get; set; }
    public DbSet<Rental>? Rentals { get; set; }

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

        modelBuilder.Entity<Customer>(c =>
        {
            c.Property(c => c.FirstName).IsRequired().HasMaxLength(30);
            c.Property(c => c.LastName).IsRequired().HasMaxLength(50);
            c.Property(c => c.PhoneNumber).IsRequired().HasMaxLength(50);
            c.Property(c => c.Pesel).IsRequired().HasMaxLength(11);
            c.Property(c => c.Gender).IsRequired();
            c.Property(c => c.EmailAddress).HasMaxLength(100);
        });


        // Car - one2many - Rental; Customer - one2many - Rental

        modelBuilder.Entity<Car>(eb =>
        {
            eb.Property(c => c.CarModelProp).IsRequired().HasMaxLength(30);
            eb.Property(c => c.Make).IsRequired().HasMaxLength(100);
            eb.Property(c => c.LicencePlateNumber).IsRequired().HasMaxLength(8);
            eb.Property(c => c.Year).IsRequired().HasComment("Car production year");
            eb.Property(c => c.Color).HasMaxLength(30);
            eb.Property(c => c.Transmission).HasMaxLength(20);
            eb.Property(c => c.Displacement).HasMaxLength(20);
            eb.Property(c => c.FuelConsumption).HasMaxLength(50);

        });

        base.OnModelCreating(modelBuilder);
    }
}
