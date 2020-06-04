using Microsoft.Extensions.DependencyInjection;

namespace Application.Handlers
{
    public static class HandlersSetup
    {
        public static IServiceCollection AddHandlers(this IServiceCollection services)
        {
            return services;
        }
    }
}
