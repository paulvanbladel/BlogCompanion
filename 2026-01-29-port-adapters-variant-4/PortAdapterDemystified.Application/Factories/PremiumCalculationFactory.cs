using PortAdapterDemystified.Domain;

namespace PortAdapterDemystified.Application.Factories;

public static class PremiumCalculationFactory
{
    public static PremiumCalculationBase Create(string variantCode)
    {
        return variantCode switch
        {
            "A" => new PremiumCalculationVariantA(),
            "B" => new PremiumCalculationVariantB(),
            _ => throw new ArgumentException($"Onbekende variantcode: {variantCode}")
        };
    }
}
