using PortAdapterDemystified.Application.Ports;
using PortAdapterDemystified.Application.UseCases;
using PortAdapterDemystified.Domain;

namespace PortAdapterDemystified.Adapters.Web.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // DI wiring (composition root)
        services.AddSingleton<PremiumCalculator>(); // domeinservice
        services.AddScoped<ICalculatePremiumUseCase, CalculatePremiumUseCase>(); // use case

        return services;
    }
}
