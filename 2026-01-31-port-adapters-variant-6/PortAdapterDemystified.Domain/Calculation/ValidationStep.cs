namespace PortAdapterDemystified.Domain.Calculation;

public sealed class ValidationStep : ICalculationStep
{
    public ICalculationStep? Next { get; set; }

    public async Task ExecuteAsync(CalculationContext context)
    {
        if (context.Age <= 0)
        {
            context.IsValid = false;
            context.ErrorMessage = "Ongeldige leeftijd opgegeven.";
            return;
        }

        await (Next?.ExecuteAsync(context) ?? Task.CompletedTask);
    }
}
