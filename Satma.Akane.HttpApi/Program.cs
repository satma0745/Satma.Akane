var webApplicationBuilder = WebApplication.CreateBuilder(args);

webApplicationBuilder.Services.AddControllers();

var webApplication = webApplicationBuilder.Build();

webApplication.MapControllers();

webApplication.Run();
