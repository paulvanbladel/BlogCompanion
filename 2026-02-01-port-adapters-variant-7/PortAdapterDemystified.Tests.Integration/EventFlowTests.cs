using PortAdapterDemystified.Application;
using PortAdapterDemystified.Domain.Events;
using PortAdapterDemystified.Domain.Handlers;
using Xunit;

namespace PortAdapterDemystified.Tests.Integration;

public sealed class EventFlowTests
{
    [Fact]
    public void FullFlow_EmitsPremiumCalculated()
    {
        var bus = new EventBus();
        PremiumCalculated? result = null;

        var validation = new ValidationHandler(bus);
        var risk = new RiskScoreHandler(bus);
        var premium = new PremiumCalculationHandler(bus);

        bus.Subscribe<CalculationRequested>(validation.Handle);
        bus.Subscribe<CalculationValidated>(risk.Handle);
        bus.Subscribe<RiskScoreCalculated>(premium.Handle);
        bus.Subscribe<PremiumCalculated>(evt => result = evt);

        bus.Publish(new CalculationRequested(30, "car", 100m));

        Assert.NotNull(result);
        Assert.Equal(400m, result!.Premium);
    }
}
