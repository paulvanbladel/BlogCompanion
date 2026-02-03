using PortAdapterDemystified.Domain;

namespace PortAdapterDemystified.Adapters.Data;

public sealed class VariantACalculation : ISubCalculation
{
    public decimal CalculatePremium(decimal basePremium)
    {
        return basePremium + (basePremium * 0.10m);
    }
}
