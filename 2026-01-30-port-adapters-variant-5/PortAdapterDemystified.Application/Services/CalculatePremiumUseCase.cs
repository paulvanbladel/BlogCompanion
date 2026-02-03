using PortAdapterDemystified.Application.Models;
using PortAdapterDemystified.Application.Ports;
using PortAdapterDemystified.Domain.Services;

namespace PortAdapterDemystified.Application.Services;

public sealed class CalculatePremiumUseCase(
    IValidationService validator,
    IRiskScoringService riskService,
    ITariffService tariffService,
    IPremiumCalculationService premiumService) : ICalculatePremiumUseCase
{
    public PremiumResult CalculatePremium(PremiumRequest request)
    {
        validator.ValidateInput(request.Age, request.CoverageAmount);

        int riskScore = riskService.CalculateRiskScore(request.Age, request.CoverageAmount);
        double basePremium = tariffService.GetBasePremium(request.CoverageAmount);
        double premiumValue = premiumService.CalculatePremium(basePremium, riskScore);

        return new PremiumResult { Premium = premiumValue, RiskScore = riskScore };
    }
}
