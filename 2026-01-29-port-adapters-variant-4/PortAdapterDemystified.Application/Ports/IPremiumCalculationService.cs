using PortAdapterDemystified.Application.Models;

namespace PortAdapterDemystified.Application.Ports;

public interface IPremiumCalculationService
{
    PremiumCalculationResult CalculatePremium(PremiumCalculationRequest request);
}
