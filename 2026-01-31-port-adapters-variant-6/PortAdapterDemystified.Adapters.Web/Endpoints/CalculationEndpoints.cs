using PortAdapterDemystified.Application;
using PortAdapterDemystified.Domain.Calculation;

namespace PortAdapterDemystified.Adapters.Web.Endpoints;

public static class CalculationEndpoints
{
    public static void MapCalculationEndpoints(this WebApplication app)
    {
        app.MapGet("/calculate/{age:int}/{loyal:bool}", async (int age, bool loyal) =>
        {
            var context = new CalculationContext
            {
                Age = age,
                IsLoyalCustomer = loyal
            };

            ICalculationStep pipeline = CalculationPipelineBuilder.BuildPipeline(includeDiscountStep: context.IsLoyalCustomer);
            await pipeline.ExecuteAsync(context);

            if (!context.IsValid)
            {
                return Results.BadRequest(new { error = context.ErrorMessage });
            }

            return Results.Ok(new { premium = context.FinalPremium });
        });
    }
}
