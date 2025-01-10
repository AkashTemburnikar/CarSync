using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopClickDrive.API.Middleware;
using ShopClickDrive.Application.DealerManagement.Services;
using ShopClickDrive.Core.Interfaces;
using ShopClickDrive.Infrastructure.Data;
using ShopClickDrive.Infrastructure.Data.DealerManagement;
using ShopClickDrive.InventoryManagement.Infrastructure;
using ShopClickDrive.InventoryManagement.Interfaces;
using ShopClickDrive.InventoryManagement.Services;
using ShopClickDrive.InventoryManagement.Validators;
using ShopClickDrive.LeadManagement.Infrastructure;
using ShopClickDrive.LeadManagement.Interfaces;
using ShopClickDrive.LeadManagement.Services;

var builder = WebApplication.CreateBuilder(args);

// Add Controllers and FluentValidation
builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        options.InvalidModelStateResponseFactory = context =>
        {
            var errors = context.ModelState
                .Where(ms => ms.Value != null && ms.Value.Errors.Any())
                .ToDictionary(
                    ms => ms.Key,
                    ms => ms.Value?.Errors.Select(e => e.ErrorMessage).ToArray()
                );

            return new BadRequestObjectResult(new
            {
                message = "Validation failed",
                errors
            });
        };
    });

// Register FluentValidation
builder.Services.AddValidatorsFromAssemblies(new[]
{
    Assembly.GetExecutingAssembly(), // API Assembly
    typeof(CreateInventoryDtoValidator).Assembly // InventoryManagement Assembly
});
builder.Services.AddValidatorsFromAssemblyContaining<Program>();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();

// Swagger for API documentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// In-Memory Database
builder.Services.AddDbContext<DealerDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ShopClickDriveDb")));

builder.Services.AddDbContext<InventoryDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ShopClickDriveDb")));

builder.Services.AddDbContext<LeadDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ShopClickDriveDb")));

// Dependency Injection
builder.Services.AddScoped<IDealerRepository, DealerRepository>();
builder.Services.AddScoped<IInventoryRepository, InventoryRepository>();
builder.Services.AddScoped<ILeadRepository, LeadRepository>();

builder.Services.AddScoped<DealerService>();
builder.Services.AddScoped<InventoryService>();
builder.Services.AddScoped<LeadService>();

var app = builder.Build();

// Development-only middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("swagger/v1/swagger.json", "ShopClickDrive v1");
        c.RoutePrefix = string.Empty;
    });
}

// Middleware
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseAuthorization();

// Map Controllers
app.MapControllers();

// Run the application
app.Run();