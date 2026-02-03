using PortAdapterDemystified.Application.Models;
using PortAdapterDemystified.Application.Ports;

namespace PortAdapterDemystified.Application.UseCases;

public sealed class CalculatePremiumUseCase(ISubCalculationSelector subCalcSelector)
{
    public CalculatePremiumResult Execute(CalculatePremiumRequest request)
    {
        var calculation = subCalcSelector.Resolve(request.VariantCode);
        if (calculation is null)
        {
            throw new InvalidOperationException($"Onbekende variantcode: {request.VariantCode}");
        }

        var premium = calculation.CalculatePremium(request.BasePremium);
        return new CalculatePremiumResult { Premium = premium };
    }
}
