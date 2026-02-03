namespace PortAdapterDemystified.Domain.Calculation;

public interface ICalculationStep
{
    ICalculationStep? Next { get; set; }
    Task ExecuteAsync(CalculationContext context);
}
