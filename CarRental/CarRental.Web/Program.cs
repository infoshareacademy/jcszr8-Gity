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
using System.Globalization;
using Hangfire;
using Serilog;
using CarRental.Logic.MailConf;

var builder = WebApplication.CreateBuilder(args);

var connectionstring = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Host.UseSerilog((hbc, loggerConfiguration) =>
{
    loggerConfiguration.MinimumLevel.Information();
    loggerConfiguration.WriteTo.MSSqlServer(connectionstring, "WebLogs",
        autoCreateSqlTable: true);

});

builder.Services.AddHangfire(configuration => configuration
    .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
    .UseSimpleAssemblyNameTypeSerializer()
    .UseRecommendedSerializerSettings()
    .UseSqlServerStorage(connectionstring, new Hangfire.SqlServer.SqlServerStorageOptions
    {
        CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
        SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
        QueuePollInterval = TimeSpan.Zero,
        UseRecommendedIsolationLevel = true,
        DisableGlobalLocks = true,
    }));

builder.Services.AddHangfireServer();


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

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

//builder.Services.AddTransient<ICustomerService, CustomerService>();
//builder.Services.AddTransient<ICarService, CarService>();
//builder.Services.AddTransient<IRentalService, RentalService>();
//builder.Services.AddTransient<ICommonService, CommonService>();

builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ICarService, CarService>(); 
builder.Services.AddScoped<IRentalService, RentalService>();
builder.Services.AddScoped<IReportService, ReportService>();
builder.Services.Configure<MailSettings>(builder.Configuration.GetSection(nameof(MailSettings)));
builder.Services.AddScoped<IEmailService, EmailService>();

//builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddAutoMapper(typeof(CustomerProfile));

//Log.Logger = new LoggerConfiguration().MinimumLevel.Information().WriteTo.MSSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), "LogsAnd", autoCreateSqlTable:true).CreateLogger();
//Serilog.Debugging.SelfLog.Enable(msg =>
//{
//    Debug.Print(msg);
//    Debugger.Break();
//});

// Validation
builder.Services.AddScoped<IValidator<CustomerViewModel>, CustomerViewModelValidator>();
builder.Services.AddScoped<IValidator<CarViewModel>, CarViewModelValidator>();
builder.Services.AddScoped<IValidator<RentalViewModel>, RentalViewModelValidator>();


builder.Services.AddScoped<UserManager<Customer>>();
builder.Services.AddScoped<RoleManager<IdentityRole<int>>>();

var app = builder.Build();

//CreateDbIfNotExists(app);

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

app.UseHangfireDashboard();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

RecurringJob.AddOrUpdate<IEmailService>("SendEmailToAdmin", service => service.SendEmailToAdmin(), Cron.Daily);

// For fixing comma vs dot problem
app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture("en-US"),
    SupportedCultures = new List<CultureInfo> { new("en-US") },
    SupportedUICultures = new List<CultureInfo> { new("en-US") }
});
app.MapRazorPages();

CreateDbIfNotExists(app);

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

        //context.Database.EnsureDeleted();
        Seed.Initialize(context, userManager, roleManager)
            .Wait();
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred creating the DB.");
    }
}
