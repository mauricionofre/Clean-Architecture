using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

namespace CleanArch.Infra.EF.Sql.Migrations
{
    public static class InitModule
    {
        public static IServiceCollection AddMigrations(this IServiceCollection services, string connectionString)
        {
            services
                .AddFluentMigratorCore()
                .ConfigureRunner(rb =>
                {
                    rb.ScanIn(Assembly.GetExecutingAssembly()).For.Migrations();
                    rb.ScanIn(Assembly.GetExecutingAssembly()).For.EmbeddedResources();

                    rb.WithGlobalConnectionString(connectionString);
                    rb.WithGlobalCommandTimeout(TimeSpan.FromMinutes(60));
                    rb.AddSqlServer2016();
                })
                .AddLogging(lb => lb.AddFluentMigratorConsole());

            return services;
        }

        public static void ExecuteMigration(this IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();

                runner.MigrateUp();
            }
        }
    }
}