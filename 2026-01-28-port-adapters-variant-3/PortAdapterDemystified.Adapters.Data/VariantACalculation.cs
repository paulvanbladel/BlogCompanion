using PortAdapterDemystified.Domain;

namespace PortAdapterDemystified.Adapters.Data;

public sealed class VariantACalculation : ISubCalculation
{
    public string VariantCode => "A";

    public decimal CalculatePremium(decimal basePremium)
    {
        return basePremium * 1.10m;
    }
}
