namespace PortAdapterDemystified.Domain.Services;

public interface ITariffService
{
    double GetBasePremium(double coverageAmount);
}
