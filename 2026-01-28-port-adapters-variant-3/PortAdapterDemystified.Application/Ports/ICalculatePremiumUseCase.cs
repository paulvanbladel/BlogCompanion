using PortAdapterDemystified.Application.Models;

namespace PortAdapterDemystified.Application.Ports;

public interface ICalculatePremiumUseCase
{
    PremiumCalculationResult CalculatePremium(PremiumCalculationRequest request);
}
