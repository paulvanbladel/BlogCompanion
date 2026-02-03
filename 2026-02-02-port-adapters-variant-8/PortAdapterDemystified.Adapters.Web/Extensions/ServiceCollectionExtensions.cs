using PortAdapterDemystified.Adapters.Config;
using PortAdapterDemystified.Application;
using PortAdapterDemystified.Domain;

namespace PortAdapterDemystified.Adapters.Web.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddSingleton<IRulesProvider>(_ =>
        {
            var configPath = Path.Combine(AppContext.BaseDirectory, "rules.json");
            return new JsonRulesProvider(configPath);
        });
        services.AddScoped<IPremiumCalculator, PremiumCalculatorEngine>();

        return services;
    }
}
