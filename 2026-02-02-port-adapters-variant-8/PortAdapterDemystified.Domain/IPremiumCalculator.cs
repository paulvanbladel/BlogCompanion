namespace PortAdapterDemystified.Domain;

public interface IPremiumCalculator
{
    decimal CalculatePremium(PremiumCalculationRequest request);
}
