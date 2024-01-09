using System.Reflection;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Satma.Akane.HttpApi.Swagger;

internal static class XmlDocumentation
{
    public static void IncludeXmlDocumentation(this SwaggerGenOptions swaggerGen)
    {
        var assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
        var xmlDocumentationFileName = $"{assemblyName}.xml";
        var xmlDocumentationFilePath = Path.Combine(AppContext.BaseDirectory, xmlDocumentationFileName);
        swaggerGen.IncludeXmlComments(xmlDocumentationFilePath);
    }
}
