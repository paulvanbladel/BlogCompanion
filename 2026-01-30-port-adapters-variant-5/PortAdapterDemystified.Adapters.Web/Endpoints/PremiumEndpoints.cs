using PortAdapterDemystified.Application.Models;
using PortAdapterDemystified.Application.Ports;

namespace PortAdapterDemystified.Adapters.Web.Endpoints;

public static class PremiumEndpoints
{
    public static void MapPremiumEndpoints(this WebApplication app)
    {
        app.MapPost("/api/premium/calculate", (PremiumRequest request, ICalculatePremiumUseCase useCase) =>
        {
            if (request is null)
            {
                return Results.BadRequest();
            }

            try
            {
                var result = useCase.CalculatePremium(request);
                return Results.Ok(result);
            }
            catch (Exception ex)
            {
                return Results.BadRequest(new { error = ex.Message });
            }
        });
    }
}
