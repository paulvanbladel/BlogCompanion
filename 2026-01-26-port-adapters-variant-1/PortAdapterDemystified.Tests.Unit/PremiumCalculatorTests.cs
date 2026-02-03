using PortAdapterDemystified.Domain;
using Xunit;

namespace PortAdapterDemystified.Tests.Unit;

public sealed class PremiumCalculatorTests
{
    [Theory]
    [InlineData("A", 0, 100.0)]
    [InlineData("A", 10, 112.0)]
    [InlineData("B", 0, 50.0)]
    [InlineData("B", 10, 65.0)]
    public void CalculatePremium_UsesVariantFormula(string variant, decimal riskScore, decimal expected)
    {
        var calculator = new PremiumCalculator();

        var result = calculator.CalculatePremium(variant, riskScore);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void CalculatePremium_ThrowsOnUnknownVariant()
    {
        var calculator = new PremiumCalculator();

        var ex = Assert.Throws<ArgumentException>(() => calculator.CalculatePremium("X", 5m));

        Assert.Contains("Onbekende variantcode", ex.Message);
    }
}
