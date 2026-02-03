using PortAdapterDemystified.Domain;

namespace PortAdapterDemystified.Application.Ports;

public interface ISubCalculationResolver
{
    ISubCalculation Resolve(string variantCode);
}
