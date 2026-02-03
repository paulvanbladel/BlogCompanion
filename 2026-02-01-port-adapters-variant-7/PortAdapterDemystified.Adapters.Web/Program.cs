using PortAdapterDemystified.Adapters.Web.Endpoints;
using PortAdapterDemystified.Adapters.Web.Extensions;
using PortAdapterDemystified.Application;
using PortAdapterDemystified.Domain.Events;
using PortAdapterDemystified.Domain.Handlers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplicationServices();

builder.Services.AddSingleton<IEventBus, EventBus>();
builder.Services.AddTransient<ValidationHandler>();
builder.Services.AddTransient<RiskScoreHandler>();
builder.Services.AddTransient<PremiumCalculationHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapCalculationEndpoints();

var eventBus = app.Services.GetRequiredService<IEventBus>();
var validationHandler = app.Services.GetRequiredService<ValidationHandler>();
var riskScoreHandler = app.Services.GetRequiredService<RiskScoreHandler>();
var premiumHandler = app.Services.GetRequiredService<PremiumCalculationHandler>();

eventBus.Subscribe<CalculationRequested>(validationHandler.Handle);
eventBus.Subscribe<CalculationValidated>(riskScoreHandler.Handle);
eventBus.Subscribe<RiskScoreCalculated>(premiumHandler.Handle);

eventBus.Subscribe<PremiumCalculated>(result =>
{
    Console.WriteLine($"[RESULT] Premium for {result.InsuranceType} insurance = {result.Premium}");
});

app.Run();

public partial class Program { }
