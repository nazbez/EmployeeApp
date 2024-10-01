using EmployeeApp.Backend.API.Infrastructure.Extensions;
using EmployeeApp.Backend.AppCore;
using EmployeeApp.Backend.Infrastructure;
using Serilog;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var environment = builder.Environment.EnvironmentName;
var assembly = Assembly.GetExecutingAssembly();

builder.Configuration
    .AddJsonFile("Configs/appsettings.json", optional: true)
    .AddJsonFile($"Configs/appsettings.{environment}.json", reloadOnChange: true, optional: false)
    .AddUserSecrets(assembly, reloadOnChange: true, optional: false);

var configuration = builder.Configuration;

builder.Host.UseSerilog((context, config) =>
    config.ReadFrom.Configuration(context.Configuration));

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddAutoMapper(assembly);
builder.Services.AddAppCore(configuration);
builder.Services.AddInfrastructure(configuration);

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

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseFluentValidationExceptionHandler();

app.MapControllers();

app.Run();
