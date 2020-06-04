using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;

namespace Infrastructure.Data
{
    public static class DataSetup
    {
        public static IServiceCollection AddData(this IServiceCollection services, string connectionString,
            bool enableLogging)
        {
            services.AddDbContext<StoreDbContext>(options =>
            {
                options.UseSqlServer(connectionString);

                if (!enableLogging) return;

                options.EnableSensitiveDataLogging();
                options.UseLoggerFactory(LoggerFactory.Create(builder =>
                {
                    builder.AddProvider(new DebugLoggerProvider());
                }));
            });

            return services;
        }
    }
}