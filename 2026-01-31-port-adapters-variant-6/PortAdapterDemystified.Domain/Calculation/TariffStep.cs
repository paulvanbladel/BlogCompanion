namespace PortAdapterDemystified.Domain.Calculation;

public sealed class TariffStep : ICalculationStep
{
    public ICalculationStep? Next { get; set; }

    public async Task ExecuteAsync(CalculationContext context)
    {
        decimal baseRate = 100m;
        context.BasePremium = baseRate * context.RiskScore;
        await (Next?.ExecuteAsync(context) ?? Task.CompletedTask);
    }
}
