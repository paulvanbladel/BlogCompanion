using PortAdapterDemystified.Application.Models;
using PortAdapterDemystified.Application.Services;
using PortAdapterDemystified.Domain.Services;
using Xunit;

namespace PortAdapterDemystified.Tests.Unit;

public sealed class CalculatePremiumUseCaseTests
{
    [Fact]
    public void CalculatePremium_OrchestratesDomainServices()
    {
        var useCase = new CalculatePremiumUseCase(
            new ValidationService(),
            new RiskScoringService(),
            new TariffService(),
            new PremiumCalculationService());

        var result = useCase.CalculatePremium(new PremiumRequest
        {
            Age = 35,
            CoverageAmount = 100000
        });

        Assert.Equal(3, result.RiskScore);
        Assert.Equal(1300d, result.Premium);
    }
}
