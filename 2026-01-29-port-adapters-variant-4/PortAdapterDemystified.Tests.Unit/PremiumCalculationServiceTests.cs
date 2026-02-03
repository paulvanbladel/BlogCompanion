using PortAdapterDemystified.Application.Models;
using PortAdapterDemystified.Application.Services;
using Xunit;

namespace PortAdapterDemystified.Tests.Unit;

public sealed class PremiumCalculationServiceTests
{
    [Fact]
    public void CalculatePremium_UsesFactory()
    {
        var service = new PremiumCalculationService();
        var request = new PremiumCalculationRequest { VariantCode = "A", BaseAmount = 200m };

        var result = service.CalculatePremium(request);

        Assert.Equal(220m, result.Premium);
    }
}
