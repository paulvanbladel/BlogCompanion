namespace PortAdapterDemystified.Domain.Calculation;

public sealed class CalculationContext
{
    public int Age { get; set; }
    public bool IsLoyalCustomer { get; set; }

    public decimal RiskScore { get; set; }
    public decimal BasePremium { get; set; }
    public decimal FinalPremium { get; set; }

    public bool IsValid { get; set; } = true;
    public string? ErrorMessage { get; set; }
}
