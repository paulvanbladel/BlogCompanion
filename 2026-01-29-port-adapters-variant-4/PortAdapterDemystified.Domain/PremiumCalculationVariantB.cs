namespace PortAdapterDemystified.Domain;

public sealed class PremiumCalculationVariantB : PremiumCalculationBase
{
    public override decimal CalculatePremium(decimal baseAmount)
    {
        return baseAmount * 1.2m;
    }
}
