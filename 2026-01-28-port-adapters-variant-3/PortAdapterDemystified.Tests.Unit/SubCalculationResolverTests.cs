using PortAdapterDemystified.Adapters.Data;
using PortAdapterDemystified.Domain;
using Xunit;

namespace PortAdapterDemystified.Tests.Unit;

public sealed class SubCalculationResolverTests
{
    [Fact]
    public void Resolve_ReturnsMatchingVariant()
    {
        ISubCalculation[] strategies =
        [
            new VariantACalculation(),
            new VariantBCalculation()
        ];

        var resolver = new SubCalculationResolver(strategies);

        var result = resolver.Resolve("b");

        Assert.IsType<VariantBCalculation>(result);
    }

    [Fact]
    public void Resolve_ThrowsOnUnknownVariant()
    {
        var resolver = new SubCalculationResolver(new ISubCalculation[] { new VariantACalculation() });

        var ex = Assert.Throws<InvalidOperationException>(() => resolver.Resolve("X"));

        Assert.Contains("No sub-calculation found", ex.Message);
    }
}
