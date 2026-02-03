namespace PortAdapterDemystified.Domain.Events;

public sealed record RiskScoreCalculated(int Age, string InsuranceType, decimal Amount, int RiskScore);
