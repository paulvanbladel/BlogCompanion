using Microsoft.Extensions.DependencyInjection;
using PortAdapterDemystified.Adapters.Web.Extensions;
using PortAdapterDemystified.Application.Models;
using PortAdapterDemystified.Application.UseCases;
using Xunit;

namespace PortAdapterDemystified.Tests.Integration;

public sealed class ServiceCollectionExtensionsTests
{
    [Fact]
    public void AddApplicationServices_WiresUseCaseAndSelector()
    {
        var services = new ServiceCollection();
        services.AddApplicationServices();

        using var provider = services.BuildServiceProvider();
        var useCase = provider.GetRequiredService<CalculatePremiumUseCase>();

        var result = useCase.Execute(new CalculatePremiumRequest { VariantCode = "B", BasePremium = 100m });

        Assert.Equal(150m, result.Premium);
    }
}
