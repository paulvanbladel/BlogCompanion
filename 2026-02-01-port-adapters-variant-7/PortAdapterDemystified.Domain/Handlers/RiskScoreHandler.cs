using PortAdapterDemystified.Application;
using PortAdapterDemystified.Domain.Events;

namespace PortAdapterDemystified.Domain.Handlers;

public sealed class RiskScoreHandler(IEventBus eventBus)
{
    public void Handle(CalculationValidated evt)
    {
        int riskScore = evt.Age > 50 ? 7 : 3;
        eventBus.Publish(new RiskScoreCalculated(evt.Age, evt.InsuranceType, evt.Amount, riskScore));
    }
}
