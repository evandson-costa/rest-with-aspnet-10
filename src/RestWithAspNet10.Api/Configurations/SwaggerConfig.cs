using Microsoft.OpenApi.Models;

namespace RestWithAspNet10.Api.Configurations;

public static class SwaggerConfig
{
    public static IServiceCollection AddSwaggerGen(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "ASP.NET 2026 REST API's from 0 to Azure and GCP with .NET 10, Docker e Kubernetes",
                Version = "v1",
                Description = $"REST API RESTful developed in course ASP.NET 2026 REST API's from 0 to Azure and GCP with .NET 10, Docker e Kubernetes",
                Contact = new OpenApiContact
                {
                    Name = "Erudio",
                    Url = new Uri("https://pub.erudio.com.br/meus-cursos")
                },
                License = new OpenApiLicense
                {
                    Name = "MIT",
                    Url = new Uri("https://pub.erudio.com.br/meus-cursos")
                }

            });
            c.CustomSchemaIds(type => type.FullName);
        });
        return services;
    }

    public static IApplicationBuilder UseSwaggerSpecification(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            c.RoutePrefix = "SwaggerUi";
            c.DocumentTitle = "ASP.NET 2026 REST API's from 0 to Azure and GCP with .NET 10, Docker e Kubernetes - Swagger UI";
        });
        return app;
    }
}
