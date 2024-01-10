using System.ComponentModel.DataAnnotations;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Satma.Akane.HttpApi.Swagger;

internal sealed class LengthAttributeSupportSchemaFilter : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        if (context.MemberInfo is null)
        {
            return;
        }

        var lengthAttributes = context.MemberInfo.GetInlineAndMetadataAttributes().OfType<LengthAttribute>();
        foreach (var lengthAttribute in lengthAttributes)
        {
            ApplyLengthAttribute(schema, lengthAttribute);
        }
    }

    private void ApplyLengthAttribute(OpenApiSchema schema, LengthAttribute lengthAttribute)
    {
        if (schema.Type == "array")
        {
            schema.MinItems = schema.MinItems is null 
                ? lengthAttribute.MinimumLength 
                : Math.Max(schema.MinItems.Value, lengthAttribute.MinimumLength);

            schema.MaxItems = schema.MaxItems is null
                ? lengthAttribute.MaximumLength
                : Math.Min(schema.MaxItems.Value, lengthAttribute.MaximumLength);
        }
        else
        {
            schema.MinLength = schema.MinLength is null 
                ? lengthAttribute.MinimumLength 
                : Math.Max(schema.MinLength.Value, lengthAttribute.MinimumLength);

            schema.MaxLength = schema.MaxLength is null
                ? lengthAttribute.MaximumLength
                : Math.Min(schema.MaxLength.Value, lengthAttribute.MaximumLength);
        }
    }
}
