using PortAdapterDemystified.Adapters.Web.Endpoints;
using PortAdapterDemystified.Adapters.Web.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices();


var app = builder.Build();

app.UseHttpsRedirection();

app.MapPremiumEndpoints();

app.Run();

public partial class Program { }
