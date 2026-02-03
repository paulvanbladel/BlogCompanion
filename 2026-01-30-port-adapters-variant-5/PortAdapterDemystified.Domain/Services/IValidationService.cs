namespace PortAdapterDemystified.Domain.Services;

public interface IValidationService
{
    void ValidateInput(int age, double coverageAmount);
}
