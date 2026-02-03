namespace PortAdapterDemystified.Domain.Services;

public interface IPremiumCalculationService
{
    double CalculatePremium(double basePremium, int riskScore);
}
