var webApplicationBuilder = WebApplication.CreateBuilder(args);
webApplicationBuilder.Services.AddControllers();
webApplicationBuilder.Build().Run();
