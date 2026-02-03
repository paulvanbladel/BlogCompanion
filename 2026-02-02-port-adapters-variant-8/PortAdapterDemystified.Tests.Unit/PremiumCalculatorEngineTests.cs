using PortAdapterDemystified.Application;
using PortAdapterDemystified.Domain;
using Xunit;

namespace PortAdapterDemystified.Tests.Unit;

public sealed class PremiumCalculatorEngineTests
{
    [Fact]
    public void CalculatePremium_AppliesRules()
    {
        var rules = new PremiumCalculationConfig
        {
            BasePremium = 100m,
            Rules =
            [
                new RuleConfig { Condition = "age > 50", SurchargeRate = 0.2m },
                new RuleConfig { Condition = "isSmoker == true", SurchargeRate = 0.1m }
            ]
        };

        var engine = new PremiumCalculatorEngine(new FakeRulesProvider(rules));
        var request = new PremiumCalculationRequest { Age = 60, IsSmoker = true };

        var premium = engine.CalculatePremium(request);

        // 100 -> +20% = 120; +10% = 132
        Assert.Equal(132m, premium);
    }

    [Fact]
    public void CalculatePremium_UsesFlatAddition()
    {
        var rules = new PremiumCalculationConfig
        {
            BasePremium = 100m,
            Rules =
            [
                new RuleConfig { Condition = "age >= 18", FlatAddition = 15m }
            ]
        };

        var engine = new PremiumCalculatorEngine(new FakeRulesProvider(rules));
        var request = new PremiumCalculationRequest { Age = 30, IsSmoker = false };

        var premium = engine.CalculatePremium(request);

        Assert.Equal(115m, premium);
    }

    [Fact]
    public void CalculatePremium_NoMatchingRules_ReturnsBasePremium()
    {
        var rules = new PremiumCalculationConfig
        {
            BasePremium = 100m,
            Rules =
            [
                new RuleConfig { Condition = "age < 18", SurchargeRate = 0.5m }
            ]
        };

        var engine = new PremiumCalculatorEngine(new FakeRulesProvider(rules));
        var request = new PremiumCalculationRequest { Age = 30, IsSmoker = false };

        var premium = engine.CalculatePremium(request);

        Assert.Equal(100m, premium);
    }

    [Fact]
    public void CalculatePremium_InvalidCondition_Throws()
    {
        var rules = new PremiumCalculationConfig
        {
            BasePremium = 100m,
            Rules =
            [
                new RuleConfig { Condition = "unknown > 10", SurchargeRate = 0.2m }
            ]
        };

        var engine = new PremiumCalculatorEngine(new FakeRulesProvider(rules));
        var request = new PremiumCalculationRequest { Age = 30, IsSmoker = false };

        Assert.Throws<InvalidOperationException>(() => engine.CalculatePremium(request));
    }

    private sealed class FakeRulesProvider(PremiumCalculationConfig config) : IRulesProvider
    {
        public PremiumCalculationConfig GetRulesConfig() => config;
    }
}
