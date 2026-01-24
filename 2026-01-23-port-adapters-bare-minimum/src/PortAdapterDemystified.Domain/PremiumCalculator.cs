namespace PortAdapterDemystified.Domain;

public static class PremiumCalculator
{
    // Pure functie: geen IO
    public static QuoteResult Calculate(QuoteRequest req, RateTable rates)
    {
        var riskFactor = 1m + (req.RiskScore / 100m) * rates.RiskMultiplier;
        var premium = req.Amount * rates.BaseRate * riskFactor;
        return new QuoteResult(decimal.Round(premium, 2));
    }
}