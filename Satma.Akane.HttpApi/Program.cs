using Microsoft.OpenApi.Models;

var webApplicationBuilder = WebApplication.CreateBuilder(args);

webApplicationBuilder.Services.AddSwaggerGen(options =>
{
    const string apiVersion = "v1";

    var openApiInfo = new OpenApiInfo
    {
        Title = "Satma.Akane",
        Version = apiVersion
    };
    
    options.SwaggerDoc(apiVersion, openApiInfo);
});
webApplicationBuilder.Services.AddControllers();

var webApplication = webApplicationBuilder.Build();

webApplication.MapControllers();

webApplication.UseSwagger();
webApplication.UseSwaggerUI();

webApplication.Run();
