using Microsoft.Extensions.DependencyInjection;
using PortAdapterDemystified.Adapters.Web.Extensions;
using PortAdapterDemystified.Application.Models;
using PortAdapterDemystified.Application.Ports;
using Xunit;

namespace PortAdapterDemystified.Tests.Integration;

public sealed class ServiceCollectionExtensionsTests
{
    [Fact]
    public void AddApplicationServices_WiresCalculationService()
    {
        var services = new ServiceCollection();
        services.AddApplicationServices();

        using var provider = services.BuildServiceProvider();
        var service = provider.GetRequiredService<IPremiumCalculationService>();

        var result = service.CalculatePremium(new PremiumCalculationRequest { VariantCode = "B", BaseAmount = 100m });

        Assert.Equal(120m, result.Premium);
    }
}
