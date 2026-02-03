using PortAdapterDemystified.Adapters.Data;
using PortAdapterDemystified.Application.Ports;
using PortAdapterDemystified.Application.UseCases;

namespace PortAdapterDemystified.Adapters.Web.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // DI wiring (composition root)
        services.AddScoped<ISubCalculationSelector, SubCalculationSelector>();
        services.AddScoped<CalculatePremiumUseCase>();

        return services;
    }
}
