using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace PortAdapterDemystified.Tests.System;

public sealed class CalculationEndpointTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public CalculationEndpointTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task PostCalculation_ReturnsAccepted()
    {
        var response = await _client.PostAsJsonAsync(
            "/calculation",
            new CalculationRequestDto(30, "car", 100m));

        Assert.Equal(HttpStatusCode.Accepted, response.StatusCode);
    }

    public sealed record CalculationRequestDto(int Age, string InsuranceType, decimal Amount);
}
