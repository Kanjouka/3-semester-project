using Scheduler.Dal;
using Scheduler.Interfaces;
using Scheduler.Model;

string _connectionString = @"";

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IEmployeeDao<Employee>>((_) => new EmployeeDao(_connectionString));
builder.Services.AddScoped<IHourSlipDaoAsync<HourSlip>>((_) => new HourSlipDao(_connectionString));

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();