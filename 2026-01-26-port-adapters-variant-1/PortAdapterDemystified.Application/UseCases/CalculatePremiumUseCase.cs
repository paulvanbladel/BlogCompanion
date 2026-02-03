using PortAdapterDemystified.Application.Models;
using PortAdapterDemystified.Application.Ports;
using PortAdapterDemystified.Domain;

namespace PortAdapterDemystified.Application.UseCases;

public sealed class CalculatePremiumUseCase(PremiumCalculator premiumCalculator) : ICalculatePremiumUseCase
{
    public PremiumResult CalculatePremium(PremiumRequest request)
    {
        var premiumValue = premiumCalculator.CalculatePremium(request.VariantCode, request.RiskScore);
        return new PremiumResult { Premium = premiumValue };
    }
}
