using EasyDapr.Core.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAppServices();  // 自动注册 scoped

var app = builder.Build();

app.MapAppServiceEndpoints(); // 自动映射接口方法为 HTTP API


app.MapGet("/", () => "Hello World!");

app.Run();
