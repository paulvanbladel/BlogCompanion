using PortAdapterDemystified.Application.Factories;
using PortAdapterDemystified.Application.Models;
using PortAdapterDemystified.Application.Ports;
using PortAdapterDemystified.Domain;

namespace PortAdapterDemystified.Application.Services;

public sealed class PremiumCalculationService : IPremiumCalculationService
{
    public PremiumCalculationResult CalculatePremium(PremiumCalculationRequest request)
    {
        PremiumCalculationBase calculator = PremiumCalculationFactory.Create(request.VariantCode);
        var premiumAmount = calculator.CalculatePremium(request.BaseAmount);
        return new PremiumCalculationResult { Premium = premiumAmount };
    }
}
