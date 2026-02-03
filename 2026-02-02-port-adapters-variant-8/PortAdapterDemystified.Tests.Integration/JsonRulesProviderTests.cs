using PortAdapterDemystified.Adapters.Config;
using PortAdapterDemystified.Application;
using PortAdapterDemystified.Domain;
using Xunit;

namespace PortAdapterDemystified.Tests.Integration;

public sealed class JsonRulesProviderTests
{
    [Fact]
    public void JsonRulesProvider_LoadsConfig()
    {
        var path = Path.Combine(AppContext.BaseDirectory, "rules.json");
        var provider = new JsonRulesProvider(path);

        PremiumCalculationConfig config = provider.GetRulesConfig();

        Assert.Equal(100m, config.BasePremium);
        Assert.NotEmpty(config.Rules);
    }

    [Fact]
    public void Engine_UsesJsonRules()
    {
        var path = Path.Combine(AppContext.BaseDirectory, "rules.json");
        var provider = new JsonRulesProvider(path);
        var engine = new PremiumCalculatorEngine(provider);

        var premium = engine.CalculatePremium(new PremiumCalculationRequest { Age = 60, IsSmoker = false });

        Assert.Equal(120m, premium);
    }

    [Fact]
    public void Engine_CombinesAgeAndSmokerRules()
    {
        var path = Path.Combine(AppContext.BaseDirectory, "rules.json");
        var provider = new JsonRulesProvider(path);
        var engine = new PremiumCalculatorEngine(provider);

        var premium = engine.CalculatePremium(new PremiumCalculationRequest { Age = 22, IsSmoker = true });

        // 100 -> +50% = 150; +10% = 165
        Assert.Equal(165m, premium);
    }

    [Fact]
    public void Engine_NoMatchingRules_ReturnsBasePremium()
    {
        var path = Path.Combine(AppContext.BaseDirectory, "rules.json");
        var provider = new JsonRulesProvider(path);
        var engine = new PremiumCalculatorEngine(provider);

        var premium = engine.CalculatePremium(new PremiumCalculationRequest { Age = 30, IsSmoker = false });

        Assert.Equal(100m, premium);
    }
}
