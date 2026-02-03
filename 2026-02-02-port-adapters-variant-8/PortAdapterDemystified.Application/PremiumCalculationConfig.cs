namespace PortAdapterDemystified.Application;

public sealed class PremiumCalculationConfig
{
    public decimal BasePremium { get; set; }
    public List<RuleConfig> Rules { get; set; } = new();
}

public sealed class RuleConfig
{
    public string Condition { get; set; } = string.Empty;
    public decimal? SurchargeRate { get; set; }
    public decimal? FlatAddition { get; set; }
}
