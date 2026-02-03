using PortAdapterDemystified.Application.Models;

namespace PortAdapterDemystified.Application.Ports;

public interface ICalculatePremiumUseCase
{
    PremiumResult CalculatePremium(PremiumRequest request);
}
