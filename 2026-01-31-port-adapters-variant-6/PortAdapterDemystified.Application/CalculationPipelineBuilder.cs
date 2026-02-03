using PortAdapterDemystified.Domain.Calculation;

namespace PortAdapterDemystified.Application;

public static class CalculationPipelineBuilder
{
    public static ICalculationStep BuildPipeline(bool includeDiscountStep)
    {
        var validation = new ValidationStep();
        var risk = new RiskScoreStep();
        var tariff = new TariffStep();
        var final = new PremiumCalculationStep();

        validation.Next = risk;
        risk.Next = tariff;

        if (includeDiscountStep)
        {
            var discount = new DiscountStep();
            tariff.Next = discount;
            discount.Next = final;
        }
        else
        {
            tariff.Next = final;
        }

        return validation;
    }
}
