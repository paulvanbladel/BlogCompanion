using Microsoft.Extensions.DependencyInjection;
using PortAdapterDemystified.Adapters.Web.Extensions;
using PortAdapterDemystified.Application.Models;
using PortAdapterDemystified.Application.Ports;
using Xunit;

namespace PortAdapterDemystified.Tests.Integration;

public sealed class ServiceCollectionExtensionsTests
{
    [Fact]
    public void AddApplicationServices_WiresUseCaseAndDomainServices()
    {
        var services = new ServiceCollection();
        services.AddApplicationServices();

        using var provider = services.BuildServiceProvider();
        var useCase = provider.GetRequiredService<ICalculatePremiumUseCase>();

        var result = useCase.CalculatePremium(new PremiumRequest { Age = 40, CoverageAmount = 100000 });

        Assert.Equal(3, result.RiskScore);
        Assert.Equal(1300d, result.Premium);
    }
}
