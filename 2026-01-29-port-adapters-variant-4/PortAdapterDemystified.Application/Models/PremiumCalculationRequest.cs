namespace PortAdapterDemystified.Application.Models;

public sealed class PremiumCalculationRequest
{
    public string VariantCode { get; set; } = string.Empty;
    public decimal BaseAmount { get; set; }
}
