using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Satma.Akane.HttpApi.Swagger;

internal sealed class ValidationProblemDetailsResponseSchema : ISchemaFilter
{
    private static readonly Dictionary<string, OpenApiSchema> validationProblemDetailsProperties = new()
    {
        ["type"] = OpenApiTypes.String,
        ["title"] = OpenApiTypes.String,
        ["status"] = OpenApiTypes.Integer,
        ["errors"] = OpenApiTypes.MapOf(OpenApiTypes.ArrayOf(OpenApiTypes.String)),
        ["traceId"] = OpenApiTypes.String
    };
    
    private static readonly OpenApiObject validationProblemDetailsExample = new()
    {
        ["type"] = new OpenApiString("https://tools.ietf.org/html/rfc9110#section-15.5.1"),
        ["title"] = new OpenApiString("One or more validation errors occurred."),
        ["status"] = new OpenApiInteger(StatusCodes.Status400BadRequest),
        ["errors"] = new OpenApiObject
        {
            ["Property1"] = new OpenApiArray
            {
                new OpenApiString("The Property1 field is required."),
                new OpenApiString("The field Property1 must be a string or array type with a minimum length of '5'.")
            },
            ["Property2"] = new OpenApiArray
            {
                new OpenApiString("The field Property2 must be between 1 and 100.")
            }
        },
        ["traceId"] = new OpenApiString("00-00000000000000000000000000000000-0000000000000000-00")
    };
    
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        if (context.Type != typeof(ProblemDetails))
        {
            return;
        }
        
        schema.Properties = validationProblemDetailsProperties;
        schema.AdditionalPropertiesAllowed = false;
            
        schema.Example = validationProblemDetailsExample;
    }
}

internal static class OpenApiTypes
{
    public static OpenApiSchema String => 
        new() { Type = "string" };

    public static OpenApiSchema Integer =>
        new() { Type = "integer", Format = "int32" };

    public static OpenApiSchema ArrayOf(OpenApiSchema elementType) =>
        new() { Type = "array", Items = elementType };

    public static OpenApiSchema MapOf(OpenApiSchema valueType) =>
        new()
        {
            Type = "object",
            Properties = new Dictionary<string, OpenApiSchema>
            {
                { "*", valueType }
            }
        };
}
