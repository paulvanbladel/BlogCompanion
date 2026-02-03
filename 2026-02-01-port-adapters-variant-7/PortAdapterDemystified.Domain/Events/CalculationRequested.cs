namespace PortAdapterDemystified.Domain.Events;

public sealed record CalculationRequested(int Age, string InsuranceType, decimal Amount);
