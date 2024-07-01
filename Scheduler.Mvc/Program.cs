using Microsoft.AspNetCore.Authentication.Cookies;
using Scheduler.ApiClient;
using Scheduler.ApiClient.Dto;
using Scheduler.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
       .AddCookie();
//builder.Services.AddSingleton<IEmployeeDao<Employee>, InMemoryEmployeeDAO>();
//builder.Services.AddSingleton<IHourSlipDaoAsync<HourSlip>, InMemoryHourSlipDAO>();
//builder.Services.AddScoped<IHourSlipDaoAsync<HourSlipDto>, MsSqlHourSlipDao>();

//For local testing
builder.Services.AddScoped<IHourSlipDaoAsync<HourSlipDto>>(provider =>
    new HourSlipApiClient("https://localhost:7114"));
builder.Services.AddScoped<IEmployeeDao<EmployeeDto>>(provider =>
    new EmployeeApiClient("https://localhost:7114"));

//For publish
//builder.Services.AddScoped<IHourSlipDaoAsync<HourSlipDto>>(provider =>
//    new HourSlipApiClient("https://scheduler.nu/api"));
//builder.Services.AddScoped<IEmployeeDao<EmployeeDto>>(provider =>
//    new EmployeeApiClient("https://scheduler.nu/api"));
var app = builder.Build();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();