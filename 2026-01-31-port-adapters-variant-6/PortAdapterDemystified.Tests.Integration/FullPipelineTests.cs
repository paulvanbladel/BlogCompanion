using PortAdapterDemystified.Application;
using PortAdapterDemystified.Domain.Calculation;
using Xunit;

namespace PortAdapterDemystified.Tests.Integration;

public sealed class FullPipelineTests
{
    [Fact]
    public async Task Pipeline_WithoutDiscount_ProducesExpectedPremium()
    {
        var pipeline = CalculationPipelineBuilder.BuildPipeline(includeDiscountStep: false);
        var context = new CalculationContext { Age = 30, IsLoyalCustomer = false };

        await pipeline.ExecuteAsync(context);

        Assert.True(context.IsValid);
        Assert.Equal(100m, context.FinalPremium);
    }
}
