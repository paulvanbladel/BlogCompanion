using PortAdapterDemystified.Application.Models;
using PortAdapterDemystified.Application.UseCases;

namespace PortAdapterDemystified.Adapters.Web.Endpoints;

public static class PremiumEndpoints
{
    public static void MapPremiumEndpoints(this WebApplication app)
    {
        app.MapPost("/api/premium/calculate", (CalculatePremiumRequest request, CalculatePremiumUseCase useCase) =>
        {
            if (request is null)
            {
                return Results.BadRequest();
            }

            try
            {
                var result = useCase.Execute(request);
                return Results.Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return Results.BadRequest(new { error = ex.Message });
            }
        });
    }
}
