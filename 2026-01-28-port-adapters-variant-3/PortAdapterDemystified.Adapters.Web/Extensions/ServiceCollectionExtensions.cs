using PortAdapterDemystified.Adapters.Data;
using PortAdapterDemystified.Application.Ports;
using PortAdapterDemystified.Application.UseCases;
using PortAdapterDemystified.Domain;

namespace PortAdapterDemystified.Adapters.Web.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // DI wiring (composition root)
        services.AddScoped<ICalculatePremiumUseCase, CalculatePremiumUseCase>();
        services.AddScoped<ISubCalculationResolver, SubCalculationResolver>();

        services.AddTransient<ISubCalculation, VariantACalculation>();
        services.AddTransient<ISubCalculation, VariantBCalculation>();

        return services;
    }
}
