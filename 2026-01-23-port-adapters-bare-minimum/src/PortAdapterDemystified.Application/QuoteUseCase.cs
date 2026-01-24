
using PortAdapterDemystified.Domain;
using PortAdapterDemystified.Domain.Ports;

namespace PortAdapterDemystified.Application.Ports;

public sealed class QuoteUseCase(IRateProvider rateProvider) : IQuoteUseCase
{
    /// <summary>
    /// Creates a quote based on the given request
    /// is use case orchestration
    /// </summary>
    /// <param name="request"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    public async Task<QuoteResult> QuoteAsync(QuoteRequest request, CancellationToken ct)
    {
        // Readonly data dependency via output port
        var rates = await rateProvider.GetRatesAsync(ct);

        // Domeinberekening
        return PremiumCalculator.Calculate(request, rates);
    }
}