namespace PortAdapterDemystified.Domain.Services;

public sealed class PremiumCalculationService : IPremiumCalculationService
{
    public double CalculatePremium(double basePremium, int riskScore)
    {
        double riskFactor = 1 + 0.1 * riskScore;
        return basePremium * riskFactor;
    }
}
