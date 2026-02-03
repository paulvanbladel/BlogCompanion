using System.Text.Json;
using PortAdapterDemystified.Application;

namespace PortAdapterDemystified.Adapters.Config;

public sealed class JsonRulesProvider(string filePath) : IRulesProvider
{
    public PremiumCalculationConfig GetRulesConfig()
    {
        string json = File.ReadAllText(filePath);
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        return JsonSerializer.Deserialize<PremiumCalculationConfig>(json, options)
               ?? throw new InvalidDataException("Configuratie kon niet ingelezen worden.");
    }
}
