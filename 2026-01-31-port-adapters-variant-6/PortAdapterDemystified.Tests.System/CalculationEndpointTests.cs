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
    public async Task Calculate_ReturnsPremium()
    {
        var response = await _client.GetAsync("/calculate/23/true");

        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();

        Assert.Contains("premium", json);
    }
}
