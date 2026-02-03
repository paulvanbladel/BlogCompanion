using PortAdapterDemystified.Application.Ports;
using PortAdapterDemystified.Application.Services;
using PortAdapterDemystified.Domain.Services;

namespace PortAdapterDemystified.Adapters.Web.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // DI wiring (composition root)
        services.AddScoped<IValidationService, ValidationService>();
        services.AddScoped<IRiskScoringService, RiskScoringService>();
        services.AddScoped<ITariffService, TariffService>();
        services.AddScoped<IPremiumCalculationService, PremiumCalculationService>();
        services.AddScoped<ICalculatePremiumUseCase, CalculatePremiumUseCase>();

        return services;
    }
}
