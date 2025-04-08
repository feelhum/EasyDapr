using EasyDapr.Core.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyDapr.Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {
            var interfaceAssembly = typeof(IService).Assembly; // EasyDapr.Abstractions
            var allAssemblies = AppDomain.CurrentDomain.GetAssemblies();

            var interfaceTypes = allAssemblies
                .SelectMany(a => a.GetTypes())
                .Where(t => typeof(IService).IsAssignableFrom(t) && t.IsInterface && t != typeof(IService))
                .ToList();

            foreach (var interfaceType in interfaceTypes)
            {
                var implType = allAssemblies
                    .SelectMany(a => a.GetTypes())
                    .FirstOrDefault(t => interfaceType.IsAssignableFrom(t) && t.IsClass);

                if (implType != null)
                {
                    services.AddScoped(interfaceType, implType);
                }
            }

            return services;
        }
    }
}
