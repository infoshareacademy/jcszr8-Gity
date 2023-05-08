using CarRental.Common;
using CarRental.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarRental.DAL.Context;

public class ApplicationContext : IdentityDbContext<Customer, IdentityRole<int>, int>
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
    }

    public DbSet<Car> Cars { get; set; }
    public DbSet<Rental> Rentals { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(b => b.MigrationsAssembly("CarRental.Web"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);

        modelBuilder.Entity<Customer>()
            .HasMany<Rental>()
            .WithOne();

        modelBuilder.Entity<Car>()
            .HasMany<Rental>()
            .WithOne();

        modelBuilder.Entity<Car>()
            .Property(e => e.Addons)
            .HasConversion(
                v => string.Join(';', v),
                v => v.Split(';', StringSplitOptions.RemoveEmptyEntries).ToList()
        );

        modelBuilder.Entity<Customer>(eb =>
        {
            eb.Property(c => c.FirstName).IsRequired().HasMaxLength(AppConfig.FirstNameMaxLength);
            eb.Property(c => c.LastName).IsRequired().HasMaxLength(AppConfig.LastNameMaxLength);
            eb.Property(c => c.PhoneNumber).IsRequired().HasMaxLength(AppConfig.PhoneNumberMaxLength);
            eb.Property(c => c.Pesel).IsRequired().IsFixedLength().HasMaxLength(AppConfig.PeselLength);
            eb.Property(c => c.Gender).IsRequired();
            eb.Property(c => c.EmailAddress).HasMaxLength(AppConfig.EmailAddressMaxLength);
        });

        modelBuilder.Entity<Car>(eb =>
        {
            eb.Property(c => c.CarModelProp).IsRequired().HasMaxLength(AppConfig.CarModelMaxLength);
            eb.Property(c => c.Make).IsRequired().HasMaxLength(AppConfig.CarMakeMaxLength);
            eb.Property(c => c.LicencePlateNumber).IsRequired().HasMaxLength(AppConfig.CarLicencePlateNumberMaxLength);
            eb.Property(c => c.Year).IsRequired().HasComment("Car production year");
            eb.Property(c => c.Displacement).HasMaxLength(AppConfig.CarDisplacementMaxLength);
            eb.Property(c => c.FuelConsumption).HasMaxLength(AppConfig.CarFuelConsumptionMaxLength);
            eb.Property(c => c.Addons).HasMaxLength(300);
            eb.Property(c => c.Price).HasColumnType("decimal").HasPrecision(7, 2);
            eb.Property(c => c.PowerInKiloWatts).HasColumnType("decimal").HasPrecision(5, 2);

            eb.Property(c => c.Created).HasDefaultValueSql("getutcdate()");
            eb.Property(c => c.Updated).ValueGeneratedOnUpdate();
            eb.Property(c => c.Description).HasMaxLength(AppConfig.CarDescriptionMaxLength);
        });

        modelBuilder.Entity<Rental>(eb =>
        {
            eb.Property(r => r.TotalCost).HasColumnType("decimal").HasPrecision(7, 2);

            eb.Property(c => c.Created).HasDefaultValueSql("getutcdate()");
            eb.Property(c => c.Updated).ValueGeneratedOnUpdate();
        });
    }
}
