using System.Reflection;
using ApiCQRSPatternTest.Data;
using ApiCQRSPatternTest.Models;
using ApiCQRSPatternTest.Models.Validation;
using ApiCQRSPatternTest.Repository;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddDbContext<DataContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("condb")
    )
);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(swaggerGenOptions =>{
    swaggerGenOptions.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
     swaggerGenOptions.IgnoreObsoleteActions();
     swaggerGenOptions.IgnoreObsoleteProperties();
     swaggerGenOptions.CustomSchemaIds(type => type.FullName);
});

//validation services
builder.Services.AddScoped<IValidator<Employee>, EmployeeValidation>();

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
