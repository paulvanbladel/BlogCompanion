using PortAdapterDemystified.Application.Ports;
using PortAdapterDemystified.Domain;

namespace PortAdapterDemystified.Adapters.Data;

public sealed class SubCalculationResolver(IEnumerable<ISubCalculation> subCalculations) : ISubCalculationResolver
{
    public ISubCalculation Resolve(string variantCode)
    {
        var strategy = subCalculations.FirstOrDefault(s =>
            s.VariantCode.Equals(variantCode, StringComparison.OrdinalIgnoreCase));

        if (strategy is null)
        {
            throw new InvalidOperationException($"No sub-calculation found for variant code: {variantCode}");
        }

        return strategy;
    }
}
