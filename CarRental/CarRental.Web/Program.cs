using System.Diagnostics;
using AutoMapper;
using CarRental.DAL.Context;
using CarRental.DAL.Entities;
using CarRental.DAL.Repositories;
using CarRental.Logic.MapperProfiles;
using CarRental.Logic.Models;
using CarRental.Logic.Services;
using CarRental.Logic.Services.IServices;
using CarRental.Logic.Validators;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using System.Globalization;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddMvc();

builder.Services.AddIdentity<Customer, IdentityRole<int>>(options =>
        options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationContext>()
    .AddDefaultTokenProviders()
    .AddRoles<IdentityRole<int>>()
    .AddDefaultUI();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddControllersWithViews();

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ICarService, CarService>(); 
builder.Services.AddScoped<IRentalService, RentalService>();
builder.Services.AddScoped<IReportService, ReportService>();

builder.Services.AddAutoMapper(typeof(CustomerProfile));

var dbConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Host.UseSerilog((hbc, loggerConfiguration) =>
{
    loggerConfiguration.ReadFrom.Configuration(hbc.Configuration);
    //loggerConfiguration.WriteTo.Console();
    //loggerConfiguration.WriteTo.File("log.txt", Serilog.Events.LogEventLevel.Information);
    //loggerConfiguration.WriteTo.File("log.txt").MinimumLevel.Information();
    //loggerConfiguration.MinimumLevel.Information();

    //loggerConfiguration.WriteTo.MSSqlServer(dbConnectionString, new MSSqlServerSinkOptions
    //{
    //    AutoCreateSqlTable = true,
    //    TableName = "CarRentalLogs"
    //});

    //loggerConfiguration.Filter.ByIncludingOnly(Matching.FromSource<CarController>());
    //loggerConfiguration.WriteTo.Seq("http://localhost:5341");
});


// Validation
builder.Services.AddScoped<IValidator<CustomerViewModel>, CustomerViewModelValidator>();
builder.Services.AddScoped<IValidator<CarViewModel>, CarViewModelValidator>();
builder.Services.AddScoped<IValidator<RentalViewModel>, RentalViewModelValidator>();


builder.Services.AddScoped<UserManager<Customer>>();
builder.Services.AddScoped<RoleManager<IdentityRole<int>>>();

var app = builder.Build();

CreateDbIfNotExists(app);

// Check if all mappings are configured
var mapper = (IMapper)app.Services.GetService(typeof(IMapper));
//mapper.ConfigurationProvider.AssertConfigurationIsValid();

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
app.UseAuthentication(); ;

app.UseAuthorization();

//app.UseSerilogRequestLogging();

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
app.MapRazorPages();

app.Run();

static void CreateDbIfNotExists(IHost host)
{
    using var scope = host.Services.CreateScope();
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<ApplicationContext>();
        var userManager = services.GetRequiredService<UserManager<Customer>>();
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole<int>>>();

        context.Database.EnsureDeleted();
        Seed.Initialize(context, userManager, roleManager)
            .Wait();
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred creating the DB.");
    }
}
