namespace PortAdapterDemystified.Domain.Calculation;

public sealed class PremiumCalculationStep : ICalculationStep
{
    public ICalculationStep? Next { get; set; }

    public async Task ExecuteAsync(CalculationContext context)
    {
        context.FinalPremium = context.BasePremium;
        await (Next?.ExecuteAsync(context) ?? Task.CompletedTask);
    }
}
