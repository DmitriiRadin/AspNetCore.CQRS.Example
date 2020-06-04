using Domain.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Helpers
{
    public static class HelpersSetup
    {
        public static IServiceCollection AddHelpers(this IServiceCollection services)
        {
            services.AddTransient<IDateTimeManager, DateTimeManager>();

            return services;
        }
    }
}