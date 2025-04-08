using EasyDapr.Core.Abstractions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace EasyDapr.Core.Extensions
{
    public static class EndpointRouteBuilderExtensions
    {
        public static void MapAppServiceEndpoints(this IEndpointRouteBuilder app)
        {
            var services = app.ServiceProvider;
            var interfaceTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(t => typeof(IService).IsAssignableFrom(t) && t.IsInterface && t != typeof(IService));

            foreach (var interfaceType in interfaceTypes)
            {
                var impl = services.GetService(interfaceType);
                if (impl == null) continue;

                var methods = interfaceType.GetMethods();

                foreach (var method in methods)
                {
                    var route = $"/{interfaceType.Name.Replace("I", "")}/{method.Name}";

                    app.MapPost(route, async (HttpContext context) =>
                    {
                        var json = await context.Request.ReadFromJsonAsync<Dictionary<string, object>>();
                        var parameters = method.GetParameters();
                        var args = parameters.Select(p =>
                        {
                            var raw = json![p.Name!];
                            return Convert.ChangeType(raw, p.ParameterType);
                        }).ToArray();

                        var result = method.Invoke(impl, args);
                        var awaited = result as Task;
                        await awaited!;
                        var prop = awaited.GetType().GetProperty("Result");
                        return Results.Ok(prop?.GetValue(awaited));
                    });
                }
            }
        }
    }

}
