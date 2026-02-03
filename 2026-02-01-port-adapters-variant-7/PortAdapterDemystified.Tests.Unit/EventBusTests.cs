using PortAdapterDemystified.Application;
using Xunit;

namespace PortAdapterDemystified.Tests.Unit;

public sealed class EventBusTests
{
    [Fact]
    public void Publish_DispatchesToSubscribers()
    {
        var bus = new EventBus();
        var called = false;

        bus.Subscribe<string>(msg => { if (msg == "ping") called = true; });
        bus.Publish("ping");

        Assert.True(called);
    }
}
