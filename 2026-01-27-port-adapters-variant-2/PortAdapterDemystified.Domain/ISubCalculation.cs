namespace PortAdapterDemystified.Domain;

/// <summary>
/// Domeininterface voor variant-specifieke premie berekening.
/// </summary>
public interface ISubCalculation
{
    decimal CalculatePremium(decimal basePremium);
}
