namespace PortAdapterDemystified.Domain.Services;

public sealed class TariffService : ITariffService
{
    public double GetBasePremium(double coverageAmount)
    {
        return coverageAmount * 0.01;
    }
}
