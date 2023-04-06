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

        modelBuilder.Entity<Customer>(eb =>
        {
            eb.Property(c => c.FirstName).IsRequired().HasMaxLength(30);
            eb.Property(c => c.LastName).IsRequired().HasMaxLength(50);
            eb.Property(c => c.PhoneNumber).IsRequired().HasMaxLength(50);
            eb.Property(c => c.Pesel).IsRequired().HasMaxLength(11);
            eb.Property(c => c.Gender).IsRequired();
            eb.Property(c => c.EmailAddress).HasMaxLength(100);
        });

        modelBuilder.Entity<Car>(eb =>
        {
            eb.Property(c => c.CarModelProp).IsRequired().HasMaxLength(50);
            eb.Property(c => c.Make).IsRequired().HasMaxLength(100);
            eb.Property(c => c.LicencePlateNumber).IsRequired().HasMaxLength(8);
            eb.Property(c => c.Year).IsRequired().HasComment("Car production year");
            eb.Property(c => c.Color).HasMaxLength(30);
            eb.Property(c => c.Transmission).HasMaxLength(20);
            eb.Property(c => c.Displacement).HasMaxLength(20);
            eb.Property(c => c.FuelConsumption).HasMaxLength(50);
            eb.Property(c => c.EngineType).HasMaxLength(20);
            eb.Property(c => c.Addons).HasMaxLength(300);
            eb.Property(c => c.Price).HasColumnType("decimal").HasPrecision(7, 2);
            eb.Property(c => c.PowerInKiloWats).HasColumnType("decimal").HasPrecision(5, 2);
        });

        modelBuilder.Entity<Rental>(eb =>
        {
            eb.Property(r => r.TotalCost).HasColumnType("decimal").HasPrecision(7, 2);
        });

        base.OnModelCreating(modelBuilder);
    }
}
