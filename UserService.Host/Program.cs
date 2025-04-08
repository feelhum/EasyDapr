using EasyDapr.Core.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAppServices();  // �Զ�ע�� scoped

var app = builder.Build();

app.MapAppServiceEndpoints(); // �Զ�ӳ��ӿڷ���Ϊ HTTP API


app.MapGet("/", () => "Hello World!");

app.Run();
