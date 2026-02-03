namespace PortAdapterDemystified.Domain.Calculation;

public sealed class DiscountStep : ICalculationStep
{
    public ICalculationStep? Next { get; set; }

    public async Task ExecuteAsync(CalculationContext context)
    {
        if (context.IsLoyalCustomer)
        {
            context.BasePremium *= 0.90m;
        }

        await (Next?.ExecuteAsync(context) ?? Task.CompletedTask);
    }
}
