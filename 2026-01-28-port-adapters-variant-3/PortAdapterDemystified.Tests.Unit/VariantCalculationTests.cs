using PortAdapterDemystified.Adapters.Data;
using Xunit;

namespace PortAdapterDemystified.Tests.Unit;

public sealed class VariantCalculationTests
{
    [Fact]
    public void VariantA_UsesPercentageRule()
    {
        var calc = new VariantACalculation();

        var result = calc.CalculatePremium(100m);

        Assert.Equal(110m, result);
        Assert.Equal("A", calc.VariantCode);
    }

    [Fact]
    public void VariantB_UsesFlatFeeRule()
    {
        var calc = new VariantBCalculation();

        var result = calc.CalculatePremium(100m);

        Assert.Equal(150m, result);
        Assert.Equal("B", calc.VariantCode);
    }
}
