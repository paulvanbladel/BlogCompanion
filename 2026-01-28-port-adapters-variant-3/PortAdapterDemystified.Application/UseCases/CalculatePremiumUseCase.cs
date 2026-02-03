using PortAdapterDemystified.Application.Models;
using PortAdapterDemystified.Application.Ports;

namespace PortAdapterDemystified.Application.UseCases;

public sealed class CalculatePremiumUseCase(ISubCalculationResolver resolver) : ICalculatePremiumUseCase
{
    public PremiumCalculationResult CalculatePremium(PremiumCalculationRequest request)
    {
        var subCalculation = resolver.Resolve(request.VariantCode);
        var premiumValue = subCalculation.CalculatePremium(request.BasePremium);
        return new PremiumCalculationResult { Premium = premiumValue };
    }
}
