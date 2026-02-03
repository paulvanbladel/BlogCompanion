using PortAdapterDemystified.Domain.Calculation;
using Xunit;

namespace PortAdapterDemystified.Tests.Unit;

public sealed class CalculationStepsTests
{
    [Fact]
    public async Task ValidationStep_ShortCircuitsOnInvalidAge()
    {
        var validation = new ValidationStep
        {
            Next = new RiskScoreStep()
        };

        var context = new CalculationContext { Age = 0 };

        await validation.ExecuteAsync(context);

        Assert.False(context.IsValid);
        Assert.Equal("Ongeldige leeftijd opgegeven.", context.ErrorMessage);
    }

    [Fact]
    public async Task DiscountStep_AppliesLoyaltyDiscount()
    {
        var discount = new DiscountStep();
        var context = new CalculationContext { IsLoyalCustomer = true, BasePremium = 100m };

        await discount.ExecuteAsync(context);

        Assert.Equal(90m, context.BasePremium);
    }
}
