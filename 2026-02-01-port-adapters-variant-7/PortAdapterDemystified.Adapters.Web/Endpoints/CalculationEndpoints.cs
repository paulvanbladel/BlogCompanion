using PortAdapterDemystified.Application;
using PortAdapterDemystified.Domain.Events;

namespace PortAdapterDemystified.Adapters.Web.Endpoints;

public static class CalculationEndpoints
{
    public static void MapCalculationEndpoints(this WebApplication app)
    {
        app.MapPost("/calculation", (CalculationRequestDto request, IEventBus eventBus) =>
        {
            eventBus.Publish(new CalculationRequested(request.Age, request.InsuranceType, request.Amount));
            return Results.Accepted("Calculation started; result will be provided via events.");
        });
    }
}
