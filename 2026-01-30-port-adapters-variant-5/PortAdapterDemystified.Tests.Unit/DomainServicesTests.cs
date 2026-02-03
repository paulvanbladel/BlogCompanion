using PortAdapterDemystified.Domain.Services;
using Xunit;

namespace PortAdapterDemystified.Tests.Unit;

public sealed class DomainServicesTests
{
    [Fact]
    public void ValidationService_ThrowsForInvalidInput()
    {
        var service = new ValidationService();

        Assert.Throws<Exception>(() => service.ValidateInput(17, 100));
        Assert.Throws<Exception>(() => service.ValidateInput(30, 0));
    }

    [Theory]
    [InlineData(25, 1)]
    [InlineData(40, 3)]
    [InlineData(60, 5)]
    public void RiskScoringService_ReturnsExpectedScore(int age, int expected)
    {
        var service = new RiskScoringService();

        var score = service.CalculateRiskScore(age, 1000);

        Assert.Equal(expected, score);
    }

    [Fact]
    public void TariffService_ReturnsOnePercentOfCoverage()
    {
        var service = new TariffService();

        var basePremium = service.GetBasePremium(200000);

        Assert.Equal(2000d, basePremium);
    }

    [Fact]
    public void PremiumCalculationService_AppliesRiskFactor()
    {
        var service = new PremiumCalculationService();

        var premium = service.CalculatePremium(100, 3);

        Assert.Equal(130d, premium);
    }
}
