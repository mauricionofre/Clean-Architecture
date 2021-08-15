using CleanArch.Application;
using CleanArch.Infra.EF.Sql;
using CleanArch.Infra.Notification;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArch.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddEntityFrameworkSql(configuration)
                .UpdateDatabase();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddApplicationModule();

            return services;
        }

        public static IServiceCollection AddNotifications(this IServiceCollection services)
        {
            services.AddNotificationsModule();

            return services;
        }
    }
}