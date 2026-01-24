namespace PortAdapterDemystified.Adapters.Data;

using PortAdapterDemystified.Domain;
using PortAdapterDemystified.Domain.Ports;

public sealed class InMemoryRateProvider : IRateProvider
{
    private static readonly RateTable Rates = new(BaseRate: 0.0125m, RiskMultiplier: 0.8m);

    public Task<RateTable> GetRatesAsync(CancellationToken ct)
        => Task.FromResult(Rates);
}
