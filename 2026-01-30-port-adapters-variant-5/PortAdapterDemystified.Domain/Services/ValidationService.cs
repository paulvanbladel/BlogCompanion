namespace PortAdapterDemystified.Domain.Services;

public sealed class ValidationService : IValidationService
{
    public void ValidateInput(int age, double coverageAmount)
    {
        if (age < 18)
        {
            throw new Exception("Aanvrager moet minimaal 18 jaar oud zijn.");
        }

        if (coverageAmount <= 0)
        {
            throw new Exception("Dekkingsbedrag moet positief zijn.");
        }
    }
}
