using PortAdapterDemystified.Domain;
using Xunit;

namespace PortAdapterDemystified.Tests.Unit;

public sealed class DomainVariantTests
{
    [Fact]
    public void VariantA_UsesMultiplier()
    {
        var calc = new PremiumCalculationVariantA();

        var result = calc.CalculatePremium(100m);

        Assert.Equal(110m, result);
    }

    [Fact]
    public void VariantB_UsesMultiplier()
    {
        var calc = new PremiumCalculationVariantB();

        var result = calc.CalculatePremium(100m);

        Assert.Equal(120m, result);
    }
}
