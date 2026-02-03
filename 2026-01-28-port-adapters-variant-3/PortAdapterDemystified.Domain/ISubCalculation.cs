namespace PortAdapterDemystified.Domain;

public interface ISubCalculation
{
    string VariantCode { get; }
    decimal CalculatePremium(decimal basePremium);
}
