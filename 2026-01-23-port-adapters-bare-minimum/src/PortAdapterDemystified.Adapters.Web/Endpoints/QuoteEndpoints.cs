using PortAdapterDemystified.Application.Ports;
using PortAdapterDemystified.Domain;

namespace PortAdapterDemystified.Adapters.Web.Endpoints;

public static class QuoteEndpoints
{
    public static void MapQuoteEndpoints(this WebApplication app)
    {
        // is web api adapter
        app.MapPost("/quote", async (QuoteDto dto, IQuoteUseCase useCase, CancellationToken ct) =>
        {
            // Web adapter -> domain request
            var req = new QuoteRequest(dto.Amount, dto.RiskScore);

            var result = await useCase.QuoteAsync(req, ct);

            // domain result -> web response
            return Results.Ok(new { result.Premium });
        });
    }
}

public sealed record QuoteDto(decimal Amount, int RiskScore);
