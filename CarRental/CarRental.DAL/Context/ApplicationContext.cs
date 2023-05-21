using CarRental.Common;
using CarRental.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CarRental.DAL.Context;

public class ApplicationContext : IdentityDbContext<Customer, IdentityRole<int>, int>
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
    }

    public DbSet<Car> Cars { get; set; }
    public DbSet<Rental> Rentals { get; set; }
    public DbSet<LastLoggedReport> LastLoggings { get; set; }
    public DbSet<VisitedCar> VisitedCars { get; set; }

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

        //modelBuilder.Entity<Rental>()
        //    .HasOne(r => r.Car)
        //    .WithMany(c => c.Rentals);

        //modelBuilder.Entity<Rental>()
        //    .HasOne(r => r.Customer)
        //    .WithMany(c => c.Rentals);

        modelBuilder.Entity<Customer>()
            .HasMany(e => e.Cars)
            .WithMany(e => e.Customers)
            .UsingEntity<Rental>(j =>
                j.Property(e => e.Created).HasDefaultValueSql("getutcdate()")
            );

        modelBuilder.Entity<Car>()
            .Property(e => e.Addons)
            .HasConversion(
                v => string.Join(';', v),
                v => v.Split(';', StringSplitOptions.RemoveEmptyEntries).ToList());

        var valueComparer = new ValueComparer<List<string>>((c1, c2) =>
            c1.SequenceEqual(c2), c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())), c => c.ToList());

        modelBuilder.Entity<Car>()
            .Property(e => e.Addons)
            .Metadata
            .SetValueComparer(valueComparer);

        modelBuilder.Entity<Customer>(eb =>
        {
            eb.Property(c => c.FirstName).HasMaxLength(AppConfig.FirstNameMaxLength); //.IsRequired().
            eb.Property(c => c.LastName).HasMaxLength(AppConfig.LastNameMaxLength); //.IsRequired().
            eb.Property(c => c.PhoneNumber).HasMaxLength(AppConfig.PhoneNumberMaxLength); //.IsRequired().
            eb.Property(c => c.Pesel).IsFixedLength().HasMaxLength(AppConfig.PeselLength); //.IsRequired();
            eb.Property(c => c.Gender); //.IsRequired();
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
            eb.Property(c => c.Image).HasMaxLength(AppConfig.CarImagePathMaxLength);
        });

        modelBuilder.Entity<Rental>(eb =>
        {
            eb.Property(r => r.TotalCost).HasColumnType("decimal").HasPrecision(7, 2);
            //eb.Property(c => c.Created).HasDefaultValueSql("getutcdate()");
            eb.Property(c => c.Updated).ValueGeneratedOnUpdate();
        });

        modelBuilder.Entity<LastLoggedReport>();

        modelBuilder.Entity<VisitedCar>();
    }
}
