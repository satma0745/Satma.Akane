using Microsoft.OpenApi.Models;

namespace Satma.Akane.HttpApi.Swagger;

internal static class Registration
{
    private const string apiVersion = "v1";

    private static readonly OpenApiInfo openApiInfo = new()
    {
        Title = "Satma.Akane",
        Version = apiVersion
    };
    
    public static void AddSwaggerSpecification(this IServiceCollection services) =>
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc(apiVersion, openApiInfo);
        });

    public static void UseSwaggerSpecification(this WebApplication webApplication)
    {
        webApplication.UseSwagger();
        webApplication.UseSwaggerUI();
    }
}
