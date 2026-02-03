using PortAdapterDemystified.Application.Models;
using PortAdapterDemystified.Application.Ports;
using PortAdapterDemystified.Application.UseCases;
using PortAdapterDemystified.Domain;
using Xunit;

namespace PortAdapterDemystified.Tests.Unit;

public sealed class CalculatePremiumUseCaseTests
{
    [Fact]
    public void Execute_UsesSelectorAndReturnsResult()
    {
        var selector = new FakeSelector();
        var useCase = new CalculatePremiumUseCase(selector);
        var request = new CalculatePremiumRequest { VariantCode = "A", BasePremium = 200m };

        var result = useCase.Execute(request);

        Assert.Equal(220m, result.Premium);
    }

    [Fact]
    public void Execute_ThrowsOnUnknownVariant()
    {
        var selector = new FakeSelector();
        var useCase = new CalculatePremiumUseCase(selector);
        var request = new CalculatePremiumRequest { VariantCode = "X", BasePremium = 200m };

        var ex = Assert.Throws<InvalidOperationException>(() => useCase.Execute(request));

        Assert.Contains("Onbekende variantcode", ex.Message);
    }

    private sealed class FakeSelector : ISubCalculationSelector
    {
        public ISubCalculation? Resolve(string variantCode)
        {
            return variantCode == "A" ? new FakeCalc() : null;
        }
    }

    private sealed class FakeCalc : ISubCalculation
    {
        public decimal CalculatePremium(decimal basePremium) => basePremium + (basePremium * 0.10m);
    }
}
