namespace PortAdapterDemystified.Domain.Ports;
/// <summary>
/// Port for retrieving rate tables
/// Is output port for readonly data
/// </summary>
public interface IRateProvider
{
    Task<RateTable> GetRatesAsync(CancellationToken ct);
}


