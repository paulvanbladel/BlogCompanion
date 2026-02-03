using PortAdapterDemystified.Application.Models;
using PortAdapterDemystified.Application.Ports;
using PortAdapterDemystified.Application.UseCases;
using PortAdapterDemystified.Domain;
using Xunit;

namespace PortAdapterDemystified.Tests.Unit;

public sealed class CalculatePremiumUseCaseTests
{
    [Fact]
    public void CalculatePremium_UsesResolver()
    {
        var useCase = new CalculatePremiumUseCase(new FakeResolver());
        var request = new PremiumCalculationRequest { VariantCode = "A", BasePremium = 200m };

        var result = useCase.CalculatePremium(request);

        Assert.Equal(220m, result.Premium);
    }

    private sealed class FakeResolver : ISubCalculationResolver
    {
        public ISubCalculation Resolve(string variantCode) => new FakeCalculation();
    }

    private sealed class FakeCalculation : ISubCalculation
    {
        public string VariantCode => "A";
        public decimal CalculatePremium(decimal basePremium) => basePremium * 1.10m;
    }
}
