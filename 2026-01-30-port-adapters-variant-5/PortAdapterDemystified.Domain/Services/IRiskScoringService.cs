namespace PortAdapterDemystified.Domain.Services;

public interface IRiskScoringService
{
    int CalculateRiskScore(int age, double coverageAmount);
}
