namespace PortAdapterDemystified.Application.Models;

public sealed class CalculatePremiumRequest
{
    public string VariantCode { get; set; } = string.Empty;
    public decimal BasePremium { get; set; }
}
