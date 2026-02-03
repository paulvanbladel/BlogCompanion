using PortAdapterDemystified.Domain;

namespace PortAdapterDemystified.Adapters.Data;

public sealed class VariantBCalculation : ISubCalculation
{
    public string VariantCode => "B";

    public decimal CalculatePremium(decimal basePremium)
    {
        return basePremium + 50m;
    }
}
