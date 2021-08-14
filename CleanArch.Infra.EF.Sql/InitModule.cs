using CleanArch.Domain.Repositories;
using CleanArch.Infra.EF.Sql.Contexts;
using CleanArch.Infra.EF.Sql.Feedbacks;
using CleanArch.Infra.EF.Sql.Migrations;
using CleanArch.Infra.EF.Sql.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CleanArch.Infra.EF.Sql
{
    public static class InitModule
    {
        public static IServiceProvider AddEntityFrameworkSql(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("default");
            services.AddDbContext<SqlDbContext>(options => options.UseSqlServer(connectionString));

            services.AddScoped<IFeedbackRepository, FeedbackRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddMigrations(connectionString);

            return services.BuildServiceProvider(false);
        }

        public static IServiceProvider UpdateDatabase(this IServiceProvider serviceProvider)
        {
            serviceProvider.ExecuteMigration();

            return serviceProvider;
        }
    }
}