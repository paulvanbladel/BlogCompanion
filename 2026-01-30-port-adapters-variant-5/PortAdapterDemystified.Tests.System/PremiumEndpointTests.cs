using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace PortAdapterDemystified.Tests.System;

public sealed class PremiumEndpointTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public PremiumEndpointTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task PostCalculate_ReturnsPremiumResult()
    {
        var response = await _client.PostAsJsonAsync(
            "/api/premium/calculate",
            new PremiumRequestDto(35, 100000));

        response.EnsureSuccessStatusCode();

        var payload = await response.Content.ReadFromJsonAsync<PremiumResultDto>();

        Assert.NotNull(payload);
        Assert.Equal(3, payload!.RiskScore);
        Assert.Equal(1300d, payload.Premium);
    }

    public sealed record PremiumRequestDto(int Age, double CoverageAmount);
    public sealed record PremiumResultDto(double Premium, int RiskScore);
}
