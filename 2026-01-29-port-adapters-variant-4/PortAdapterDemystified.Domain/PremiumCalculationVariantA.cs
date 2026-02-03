namespace PortAdapterDemystified.Domain;

public sealed class PremiumCalculationVariantA : PremiumCalculationBase
{
    public override decimal CalculatePremium(decimal baseAmount)
    {
        return baseAmount * 1.1m;
    }
}
