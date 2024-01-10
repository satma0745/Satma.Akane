using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Satma.Akane.HttpApi.Swagger;

var webApplicationBuilder = WebApplication.CreateBuilder(args);

webApplicationBuilder.Services.AddSwaggerSpecification();
webApplicationBuilder.Services.AddControllers(options =>
{
    var stjValidationMetadataProvider = new SystemTextJsonValidationMetadataProvider();
    options.ModelMetadataDetailsProviders.Add(stjValidationMetadataProvider);
});

var webApplication = webApplicationBuilder.Build();

webApplication.MapControllers();
webApplication.UseSwaggerSpecification();

webApplication.Run();
