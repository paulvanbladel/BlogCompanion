using PortAdapterDemystified.Application;
using PortAdapterDemystified.Domain.Events;

namespace PortAdapterDemystified.Domain.Handlers;

public sealed class ValidationHandler(IEventBus eventBus)
{
    public void Handle(CalculationRequested evt)
    {
        if (evt.Age <= 0 || evt.Amount <= 0)
        {
            return;
        }

        eventBus.Publish(new CalculationValidated(evt.Age, evt.InsuranceType, evt.Amount));
    }
}
