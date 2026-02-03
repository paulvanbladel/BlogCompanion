namespace PortAdapterDemystified.Domain.Events;

public sealed record CalculationValidated(int Age, string InsuranceType, decimal Amount);
