using PortAdapterDemystified.Domain;

namespace PortAdapterDemystified.Adapters.Web.Endpoints;

public static class PremiumEndpoints
{
    public static void MapPremiumEndpoints(this WebApplication app)
    {
        app.MapPost("/api/premium/calculate", (PremiumCalculationRequest request, IPremiumCalculator calculator) =>
        {
            var result = calculator.CalculatePremium(request);
            return Results.Ok(result);
        });
    }
}
