using CleanArch.Application.Features.Feedbacks;
using CleanArch.Application.Features.Users;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CleanArch.Application
{
    public static class InitModule
    {
        public static IServiceCollection AddApplicationModule(this IServiceCollection services)
        {
            services.AddScoped<IFeedbackService, FeedbackService>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}