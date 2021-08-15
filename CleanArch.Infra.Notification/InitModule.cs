using CleanArch.Domain.Notifications;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CleanArch.Infra.Notification
{
    public static class InitModule
    {
        public static IServiceCollection AddNotificationsModule(this IServiceCollection services)
        {
            services.AddScoped<IFeedbackNotification, FeedbackNotification>();

            return services;
        }
    }
}