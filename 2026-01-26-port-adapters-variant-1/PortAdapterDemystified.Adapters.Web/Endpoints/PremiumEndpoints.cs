using PortAdapterDemystified.Application.Models;
using PortAdapterDemystified.Application.Ports;

namespace PortAdapterDemystified.Adapters.Web.Endpoints;

public static class PremiumEndpoints
{
    public static void MapPremiumEndpoints(this WebApplication app)
    {
        // Web API adapter
        app.MapPost("/api/premium/calculate", (PremiumRequest request, ICalculatePremiumUseCase useCase) =>
        {
            if (request is null)
            {
                return Results.BadRequest();
            }

            var result = useCase.CalculatePremium(request);
            return Results.Ok(result);
        });
    }
}
