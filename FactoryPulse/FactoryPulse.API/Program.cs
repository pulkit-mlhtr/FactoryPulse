using FactoryPulse.API.Filters;
using FactoryPulse.Application.Services;
using FactoryPulse.Application.Services.Interface;
using FactoryPulse.Domain.Interface;
using FactoryPulse.Domain.Interfaces;
using FactoryPulse.Infrastructure.Context;
using FactoryPulse.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire client integrations.
builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddProblemDetails();

// Add Swagger / OpenAPI generation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddTransient<AppExceptionFilter>();
builder.Services.AddTransient<IEquipmentRepository,EquipmentRepository>();
builder.Services.AddTransient<IEquipmentService, EquipmentService>();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Postgres")));

builder.Services.AddControllers(options =>
{
    options.Filters.Add<AppExceptionFilter>();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapDefaultEndpoints();
app.UseRouting();
app.UseSwagger();
app.UseSwaggerUI();
app.UseFileServer();

// Map controller routes so Swagger UI can call your API endpoints
app.MapControllers();

app.Run();
