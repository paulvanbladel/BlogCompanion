using PortAdapterDemystified.Adapters.Data;
using Xunit;

namespace PortAdapterDemystified.Tests.Unit;

public sealed class VariantCalculationTests
{
    [Fact]
    public void VariantA_AddsTenPercent()
    {
        var calc = new VariantACalculation();

        var result = calc.CalculatePremium(100m);

        Assert.Equal(110m, result);
    }

    [Fact]
    public void VariantB_AddsFlatFee()
    {
        var calc = new VariantBCalculation();

        var result = calc.CalculatePremium(100m);

        Assert.Equal(150m, result);
    }
}
