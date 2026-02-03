namespace PortAdapterDemystified.Domain.Events;

public sealed record PremiumCalculated(int Age, string InsuranceType, decimal Amount, int RiskScore, decimal Premium);
