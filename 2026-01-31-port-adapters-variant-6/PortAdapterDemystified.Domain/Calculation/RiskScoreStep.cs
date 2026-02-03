namespace PortAdapterDemystified.Domain.Calculation;

public sealed class RiskScoreStep : ICalculationStep
{
    public ICalculationStep? Next { get; set; }

    public async Task ExecuteAsync(CalculationContext context)
    {
        context.RiskScore = context.Age < 25 ? 1.5m : 1.0m;
        await (Next?.ExecuteAsync(context) ?? Task.CompletedTask);
    }
}
