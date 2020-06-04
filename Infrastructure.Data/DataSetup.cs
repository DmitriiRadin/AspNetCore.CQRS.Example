using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Data
{
    public static class DataSetup
    {
        public static IServiceCollection AddData(this IServiceCollection services)
        {
            return services;
        }
    }
}