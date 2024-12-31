
using API.Endpoints;
using API.Infrastructure;
using API.Validators;
using Application.Interfaces;
using Application.Services;
using Domain.Interfaces;
using FluentValidation;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console() // Write log output to the console
    .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day) // Write logs to a file with daily rolling
    .Enrich.FromLogContext() // Adds additional context to logs
    .CreateLogger(); // Create the Serilog logger

var builder = WebApplication.CreateBuilder(args);

// Use Serilog as the logging provider
builder.Host.UseSerilog();

// Configure Entity Framework with PostgreSQL database
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add FluentValidation validators from the assembly
builder.Services.AddValidatorsFromAssemblyContaining<CreateProductDtoValidator>();

// Register application services and repositories for dependency injection
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

// Add the default logging services
builder.Services.AddLogging();

// Add global exception handling using a custom exception handler
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

// Add support for Problem Details responses
builder.Services.AddProblemDetails();

// Add Swagger for API documentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline based on the application environment
if (app.Environment.IsDevelopment())
{
    // Enable Swagger UI and API documentation in development
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Enforce HTTPS redirection for secure communication
app.UseHttpsRedirection();

// Use the global exception handler middleware
app.UseExceptionHandler();

// Map endpoints from separate classes
app.MapProductEndpoints(); // Registers product endpoints

// Start the application
app.Run();

// Partial Program class to allow access to the Program type in integration tests
public partial class Program { }