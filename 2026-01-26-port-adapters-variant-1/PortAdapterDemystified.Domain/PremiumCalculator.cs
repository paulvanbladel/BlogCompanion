namespace PortAdapterDemystified.Domain;

public sealed class PremiumCalculator
{
    // Static dispatch: kies formule op basis van variantcode.
    public decimal CalculatePremium(string variantCode, decimal riskScore)
    {
        return variantCode switch
        {
            "A" => CalculateVariantA(riskScore),
            "B" => CalculateVariantB(riskScore),
            _ => throw new ArgumentException($"Onbekende variantcode: {variantCode}")
        };
    }

    private static decimal CalculateVariantA(decimal riskScore)
    {
        const decimal baseAmount = 100m;
        const decimal factor = 1.2m;
        return baseAmount + (riskScore * factor);
    }

    private static decimal CalculateVariantB(decimal riskScore)
    {
        const decimal baseAmount = 50m;
        const decimal factor = 1.5m;
        return baseAmount + (riskScore * factor);
    }
}
