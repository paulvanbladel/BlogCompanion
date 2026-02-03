namespace PortAdapterDemystified.Domain.Services;

public sealed class RiskScoringService : IRiskScoringService
{
    public int CalculateRiskScore(int age, double coverageAmount)
    {
        if (age < 30)
        {
            return 1;
        }

        if (age < 50)
        {
            return 3;
        }

        return 5;
    }
}
