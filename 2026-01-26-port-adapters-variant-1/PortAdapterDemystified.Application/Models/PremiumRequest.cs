namespace PortAdapterDemystified.Application.Models;

public sealed class PremiumRequest
{
    public string VariantCode { get; set; } = string.Empty;
    public decimal RiskScore { get; set; }
}
