
using PortAdapterDemystified.Domain;

namespace PortAdapterDemystified.Application.Ports;
/// <summary>
/// Port for quoting use case
/// Is input port for quoting use case
/// </summary>
public interface IQuoteUseCase
{
    Task<QuoteResult> QuoteAsync(QuoteRequest request, CancellationToken ct);
}
