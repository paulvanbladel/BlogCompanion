using PortAdapterDemystified.Adapters.Data;
using PortAdapterDemystified.Application.Ports;
using PortAdapterDemystified.Domain.Ports;

namespace PortAdapterDemystified.Adapters.Web.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // DI wiring (composition root)
        services.AddSingleton<IRateProvider, InMemoryRateProvider>(); // readonly adapter
        services.AddScoped<IQuoteUseCase, QuoteUseCase>();            // application

        return services;
    }
}
