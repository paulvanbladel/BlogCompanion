using PortAdapterDemystified.Application.Models;
using PortAdapterDemystified.Application.UseCases;
using PortAdapterDemystified.Domain;
using Xunit;

namespace PortAdapterDemystified.Tests.Unit;

public sealed class CalculatePremiumUseCaseTests
{
    [Fact]
    public void CalculatePremium_ReturnsPremiumResult()
    {
        var calculator = new PremiumCalculator();
        var useCase = new CalculatePremiumUseCase(calculator);
        var request = new PremiumRequest
        {
            VariantCode = "A",
            RiskScore = 20m
        };

        var result = useCase.CalculatePremium(request);

        Assert.Equal(124m, result.Premium);
    }
}
