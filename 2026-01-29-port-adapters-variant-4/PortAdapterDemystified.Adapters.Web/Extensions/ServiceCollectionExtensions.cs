using PortAdapterDemystified.Application.Ports;
using PortAdapterDemystified.Application.Services;

namespace PortAdapterDemystified.Adapters.Web.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // DI wiring (composition root)
        services.AddScoped<IPremiumCalculationService, PremiumCalculationService>();

        return services;
    }
}
