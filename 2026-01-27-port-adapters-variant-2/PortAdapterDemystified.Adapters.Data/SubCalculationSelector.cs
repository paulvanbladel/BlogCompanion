using PortAdapterDemystified.Application.Ports;
using PortAdapterDemystified.Domain;

namespace PortAdapterDemystified.Adapters.Data;

/// <summary>
/// Adapter-implementatie van de outbound port voor variantselectie.
/// </summary>
public sealed class SubCalculationSelector : ISubCalculationSelector
{
    private readonly Dictionary<string, ISubCalculation> _calculations = new()
    {
        { "A", new VariantACalculation() },
        { "B", new VariantBCalculation() }
    };

    public ISubCalculation? Resolve(string variantCode)
    {
        _calculations.TryGetValue(variantCode, out var calc);
        return calc;
    }
}
