using PortAdapterDemystified.Domain;

namespace PortAdapterDemystified.Application.Ports;

/// <summary>
/// Outbound port voor variantselectie.
/// </summary>
public interface ISubCalculationSelector
{
    ISubCalculation? Resolve(string variantCode);
}
