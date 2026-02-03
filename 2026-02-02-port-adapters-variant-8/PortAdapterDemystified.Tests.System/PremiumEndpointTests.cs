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
    public async Task PostCalculate_ReturnsPremium()
    {
        var response = await _client.PostAsJsonAsync(
            "/api/premium/calculate",
            new PremiumCalculationRequestDto(60, false));

        response.EnsureSuccessStatusCode();

        var premium = await response.Content.ReadFromJsonAsync<decimal>();

        Assert.Equal(120m, premium);
    }

    [Fact]
    public async Task PostCalculate_ReturnsPremium_WithSmokerSurcharge()
    {
        var response = await _client.PostAsJsonAsync(
            "/api/premium/calculate",
            new PremiumCalculationRequestDto(60, true));

        response.EnsureSuccessStatusCode();

        var premium = await response.Content.ReadFromJsonAsync<decimal>();

        Assert.Equal(132m, premium);
    }

    public sealed record PremiumCalculationRequestDto(int Age, bool IsSmoker);
}
