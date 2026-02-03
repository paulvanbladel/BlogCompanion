using System.Reflection;
using PortAdapterDemystified.Domain;

namespace PortAdapterDemystified.Application;

public sealed class PremiumCalculatorEngine(IRulesProvider rulesProvider) : IPremiumCalculator
{
    public decimal CalculatePremium(PremiumCalculationRequest request)
    {
        PremiumCalculationConfig config = rulesProvider.GetRulesConfig();
        decimal premium = config.BasePremium;

        foreach (RuleConfig rule in config.Rules)
        {
            if (EvaluateCondition(rule.Condition, request))
            {
                if (rule.SurchargeRate.HasValue)
                {
                    premium += premium * rule.SurchargeRate.Value;
                }

                if (rule.FlatAddition.HasValue)
                {
                    premium += rule.FlatAddition.Value;
                }
            }
        }

        return premium;
    }

    private static bool EvaluateCondition(string condition, PremiumCalculationRequest request)
    {
        string cond = condition.Trim();
        string[] ops = [">=", "<=", "==", "!=", ">", "<"];
        string? opFound = null;

        foreach (string op in ops)
        {
            if (cond.Contains(op, StringComparison.Ordinal))
            {
                opFound = op;
                break;
            }
        }

        if (opFound is null)
        {
            throw new InvalidOperationException($"Ongeldig conditieformaat: {condition}");
        }

        string[] parts = cond.Split(opFound, StringSplitOptions.TrimEntries);
        if (parts.Length != 2)
        {
            throw new InvalidOperationException($"Ongeldig conditieformaat: {condition}");
        }

        string leftExpr = parts[0];
        string rightExpr = parts[1];

        PropertyInfo? prop = typeof(PremiumCalculationRequest).GetProperty(
            leftExpr, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
        if (prop is null)
        {
            throw new InvalidOperationException($"Ongeldige parameter in conditie: {leftExpr}");
        }

        object leftValue = prop.GetValue(request) ?? throw new InvalidOperationException("Null value");

        object rightValue;
        if (prop.PropertyType == typeof(bool))
        {
            if (!bool.TryParse(rightExpr, out bool boolVal))
            {
                throw new InvalidOperationException($"Verwachte boolean in conditie, kreeg: {rightExpr}");
            }

            rightValue = boolVal;
        }
        else
        {
            if (decimal.TryParse(rightExpr, out decimal decVal))
            {
                rightValue = Convert.ChangeType(decVal, prop.PropertyType);
            }
            else
            {
                throw new InvalidOperationException($"Verwachte numerieke waarde in conditie, kreeg: {rightExpr}");
            }
        }

        int comparison = Comparer<object>.Default.Compare(leftValue, rightValue);
        return opFound switch
        {
            ">" => comparison > 0,
            ">=" => comparison >= 0,
            "<" => comparison < 0,
            "<=" => comparison <= 0,
            "==" => comparison == 0,
            "!=" => comparison != 0,
            _ => false
        };
    }
}
