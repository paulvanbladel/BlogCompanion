using PortAdapterDemystified.Application.Models;
using PortAdapterDemystified.Application.Ports;

namespace PortAdapterDemystified.Adapters.Web.Endpoints;

public static class PremiumCalculationEndpoints
{
    public static void MapPremiumCalculationEndpoints(this WebApplication app)
    {
        app.MapPost("/api/premium-calculation/calculate", (PremiumCalculationRequest request, IPremiumCalculationService service) =>
        {
            if (request is null)
            {
                return Results.BadRequest();
            }

            try
            {
                var result = service.CalculatePremium(request);
                return Results.Ok(result);
            }
            catch (ArgumentException ex)
            {
                return Results.BadRequest(new { error = ex.Message });
            }
        });
    }
}
