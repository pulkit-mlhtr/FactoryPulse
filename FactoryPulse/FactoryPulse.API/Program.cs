using FactoryPulse.API.Filters;
using FactoryPulse.API.Hubs;
using FactoryPulse.API.Services;
using FactoryPulse.Application.Interface;
using FactoryPulse.Application.Services;
using FactoryPulse.Domain.Interface;
using FactoryPulse.Domain.Interfaces;
using FactoryPulse.Infrastructure.Context;
using FactoryPulse.Infrastructure.Repository;
using FluentValidation;
using FluentValidation.AspNetCore;
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

builder.Services.AddSignalR();

builder.Services.AddTransient<AppExceptionFilter>();
builder.Services.AddTransient<IEquipmentRepository,EquipmentRepository>();
builder.Services.AddTransient<IEquipmentService, EquipmentService>();
builder.Services.AddScoped<IEquipmentNotifier, EquipmentNotifierService>();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Postgres")));

builder.Services.AddControllers(options =>
{
    options.Filters.Add<AppExceptionFilter>();
})
// Register FluentValidation validators from this assembly
.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<FactoryPulse.API.Validators.UpdateEquipmentStateRequestValidator>());

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

app.MapControllers();
app.MapHub<EquipmentHub>("/equipmentHub");

app.Run();
