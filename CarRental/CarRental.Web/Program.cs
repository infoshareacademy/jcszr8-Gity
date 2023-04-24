using AutoMapper;
using CarRental.DAL.Context;
using CarRental.DAL.Repositories;
using CarRental.Logic.MapperProfiles;
using CarRental.Logic.Services;
using CarRental.Logic.Services.IServices;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

builder.Services.AddTransient<ICustomerService, CustomerService>();
builder.Services.AddTransient<ICarService, CarService>();
builder.Services.AddTransient<IRentalService, RentalService>();
builder.Services.AddTransient<ISearchService, SearchService>();

//builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddAutoMapper(typeof(CustomerProfile));

var app = builder.Build();

CreateDbIfNotExists(app);

// Check if all mappings are configured
var mapper = (IMapper)app.Services.GetService(typeof(IMapper));
mapper.ConfigurationProvider.AssertConfigurationIsValid();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


// For fixing comma vs dot problem
app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture("en-US"),
    SupportedCultures = new List<CultureInfo> { new("en-US") },
    SupportedUICultures = new List<CultureInfo> { new("en-US") }
});

app.Run();


static void CreateDbIfNotExists(IHost host)
{
    using var scope = host.Services.CreateScope();
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<ApplicationContext>();

        context.Database.EnsureDeleted();
        Seed.Initialize(context);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred creating the DB.");
    }
}
