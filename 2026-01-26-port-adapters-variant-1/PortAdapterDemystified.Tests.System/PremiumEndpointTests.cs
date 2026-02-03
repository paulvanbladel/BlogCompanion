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
            new PremiumRequestDto("A", 42.5m));

        response.EnsureSuccessStatusCode();

        var payload = await response.Content.ReadFromJsonAsync<PremiumResultDto>();

        Assert.NotNull(payload);
        Assert.Equal(151.00m, payload!.Premium);
    }

    public sealed record PremiumRequestDto(string VariantCode, decimal RiskScore);
    public sealed record PremiumResultDto(decimal Premium);
}
