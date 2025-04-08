using System.ComponentModel.DataAnnotations;
using FreeSql;
using Microsoft.Extensions.DependencyInjection;
using DataType = FreeSql.DataType;
namespace EasyDapr.Core.Modules
{
    public static class FreeSqlModules
    {
        public static IServiceCollection AddFreeSql(this IServiceCollection services)
        {
            var fsql = new FreeSqlBuilder()
                .UseConnectionString(DataType.MySql, "Your-Connection-String")
                .Build();

            services.AddSingleton(fsql);
            return services;
        }
    }
}
