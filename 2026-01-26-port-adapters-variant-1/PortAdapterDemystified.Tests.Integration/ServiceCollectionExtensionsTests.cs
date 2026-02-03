using Microsoft.Extensions.DependencyInjection;
using PortAdapterDemystified.Adapters.Web.Extensions;
using PortAdapterDemystified.Application.Models;
using PortAdapterDemystified.Application.Ports;
using Xunit;

namespace PortAdapterDemystified.Tests.Integration;

public sealed class ServiceCollectionExtensionsTests
{
    [Fact]
    public void AddApplicationServices_WiresUseCaseAndDomain()
    {
        var services = new ServiceCollection();
        services.AddApplicationServices();

        using var provider = services.BuildServiceProvider();
        var useCase = provider.GetRequiredService<ICalculatePremiumUseCase>();

        var result = useCase.CalculatePremium(new PremiumRequest { VariantCode = "B", RiskScore = 10m });

        Assert.Equal(65m, result.Premium);
    }
}
