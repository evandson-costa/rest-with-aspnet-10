using Scalar.AspNetCore;

namespace RestWithAspNet10.Api.Configurations;

public static class ScalarConfig
{
    public static WebApplication UseScalarConfiguration(this WebApplication app)
    {
        app.MapScalarApiReference("/scalar", options =>
         {
            options
            .WithTitle("ASP.NET 2026 REST API's from 0 to Azure and GCP with .NET 10, Docker e Kubernetes - Scalar API Reference")
            .WithOpenApiRoutePattern("swagger/v1/swagger.json");

         });
        return app;
    }
}