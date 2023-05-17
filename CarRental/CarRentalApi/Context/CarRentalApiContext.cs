using CarRentalApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRentalApi.Context;

public class CarRentalApiContext : DbContext
{
    public CarRentalApiContext(DbContextOptions<CarRentalApiContext> options)
        : base(options)
    {
    }

    public DbSet<LastLoggedReport> LastLoggings { get; set; }
    public DbSet<VisitedCar> VisitedCars { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(b => b.MigrationsAssembly("CarRentalApi"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<LastLoggedReport>()
            .HasIndex(u => u.UserId)
            .IsUnique();

        modelBuilder.Entity<LastLoggedReport>()
            .HasData(
                new { Id = 1, UserId = 1, LastLogged = DateTime.Now.AddDays(-3).AddMinutes(-10) },
                new { Id = 2, UserId = 2, LastLogged = DateTime.Now.AddDays(-2).AddHours(1) },
                new { Id = 3, UserId = 3, LastLogged = DateTime.Now.AddDays(-1).AddHours(2).AddMinutes(10) },
                new { Id = 4, UserId = 4, LastLogged = DateTime.Now }
            );

        modelBuilder.Entity<VisitedCar>()
            .HasIndex(u => u.UserId)
            .IsUnique();
    }
}
