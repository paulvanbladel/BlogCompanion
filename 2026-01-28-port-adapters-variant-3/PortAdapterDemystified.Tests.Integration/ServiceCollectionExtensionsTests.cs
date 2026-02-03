using Microsoft.Extensions.DependencyInjection;
using PortAdapterDemystified.Adapters.Web.Extensions;
using PortAdapterDemystified.Application.Models;
using PortAdapterDemystified.Application.Ports;
using Xunit;

namespace PortAdapterDemystified.Tests.Integration;

public sealed class ServiceCollectionExtensionsTests
{
    [Fact]
    public void AddApplicationServices_WiresResolverAndVariants()
    {
        var services = new ServiceCollection();
        services.AddApplicationServices();

        using var provider = services.BuildServiceProvider();
        var useCase = provider.GetRequiredService<ICalculatePremiumUseCase>();

        var result = useCase.CalculatePremium(new PremiumCalculationRequest { VariantCode = "B", BasePremium = 100m });

        Assert.Equal(150m, result.Premium);
    }
}
