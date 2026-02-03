using PortAdapterDemystified.Application;
using PortAdapterDemystified.Domain.Calculation;
using Xunit;

namespace PortAdapterDemystified.Tests.Unit;

public sealed class PipelineBuilderTests
{
    [Fact]
    public async Task Pipeline_WithDiscount_IncludesDiscountStep()
    {
        var pipeline = CalculationPipelineBuilder.BuildPipeline(includeDiscountStep: true);
        var context = new CalculationContext { Age = 23, IsLoyalCustomer = true };

        await pipeline.ExecuteAsync(context);

        Assert.True(context.IsValid);
        Assert.Equal(135m, context.FinalPremium);
    }
}
