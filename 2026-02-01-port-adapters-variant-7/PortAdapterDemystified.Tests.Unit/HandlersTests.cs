using PortAdapterDemystified.Application;
using PortAdapterDemystified.Domain.Events;
using PortAdapterDemystified.Domain.Handlers;
using Xunit;

namespace PortAdapterDemystified.Tests.Unit;

public sealed class HandlersTests
{
    [Fact]
    public void ValidationHandler_PublishesValidatedEvent()
    {
        var bus = new EventBus();
        CalculationValidated? published = null;
        bus.Subscribe<CalculationValidated>(evt => published = evt);

        var handler = new ValidationHandler(bus);
        handler.Handle(new CalculationRequested(30, "car", 100m));

        Assert.NotNull(published);
        Assert.Equal(30, published!.Age);
    }

    [Fact]
    public void RiskScoreHandler_PublishesRiskScore()
    {
        var bus = new EventBus();
        RiskScoreCalculated? published = null;
        bus.Subscribe<RiskScoreCalculated>(evt => published = evt);

        var handler = new RiskScoreHandler(bus);
        handler.Handle(new CalculationValidated(60, "car", 100m));

        Assert.NotNull(published);
        Assert.Equal(7, published!.RiskScore);
    }
}
