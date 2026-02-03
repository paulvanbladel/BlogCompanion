namespace PortAdapterDemystified.Adapters.Web;

public sealed class CalculationRequestDto
{
    public int Age { get; set; }
    public string InsuranceType { get; set; } = string.Empty;
    public decimal Amount { get; set; }
}
