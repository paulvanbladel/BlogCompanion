using PortAdapterDemystified.Application;
using PortAdapterDemystified.Domain.Events;

namespace PortAdapterDemystified.Domain.Handlers;

public sealed class PremiumCalculationHandler(IEventBus eventBus)
{
    public void Handle(RiskScoreCalculated evt)
    {
        decimal premium = evt.Amount + (evt.RiskScore * 100m);
        eventBus.Publish(new PremiumCalculated(evt.Age, evt.InsuranceType, evt.Amount, evt.RiskScore, premium));
    }
}
