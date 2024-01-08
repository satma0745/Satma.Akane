using Satma.Akane.HttpApi.Swagger;

var webApplicationBuilder = WebApplication.CreateBuilder(args);

webApplicationBuilder.Services.AddSwaggerSpecification();
webApplicationBuilder.Services.AddControllers();

var webApplication = webApplicationBuilder.Build();

webApplication.MapControllers();
webApplication.UseSwaggerSpecification();

webApplication.Run();
