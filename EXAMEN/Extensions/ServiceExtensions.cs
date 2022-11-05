using EXAMEN.Contracts;
using EXAMEN.LoggerService;
using EXAMEN.Services;

namespace API.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddConfigurationServices(this IServiceCollection services)
        {
            AddLoggerService(services);
            AddUnitOfWork(services);
            return services;
        }
        public static void AddLoggerService(IServiceCollection services)
        {
            services.AddScoped<ILoggerManager, LoggerManager>();
        }
        public static void AddUnitOfWork(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
