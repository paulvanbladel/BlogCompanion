using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace PortAdapterDemystified.Tests.System;

public sealed class PremiumCalculationEndpointTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public PremiumCalculationEndpointTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task PostCalculate_ReturnsPremiumResult()
    {
        var response = await _client.PostAsJsonAsync(
            "/api/premium-calculation/calculate",
            new PremiumCalculationRequestDto("A", 100m));

        response.EnsureSuccessStatusCode();

        var payload = await response.Content.ReadFromJsonAsync<PremiumCalculationResultDto>();

        Assert.NotNull(payload);
        Assert.Equal(110m, payload!.Premium);
    }

    public sealed record PremiumCalculationRequestDto(string VariantCode, decimal BaseAmount);
    public sealed record PremiumCalculationResultDto(decimal Premium);
}
