using AdministrativoEscolar.CDU.Services;
using AdministrativoEscolar.CDU.Services.Interfaces;
using AdministrativoEscolar.CORE.Notification;
using AdministrativoEscolar.READ.Queries.AlunoQ;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace AdministrativoEscolar.API.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            RegisterNotification(services);
            RegisterQuery(services);
            RegisterService(services);

            return services;
        }

        private static void RegisterNotification(IServiceCollection services)
        {
            services.AddScoped<INotificador, Notificador>();
        }

        private static void RegisterQuery(IServiceCollection services)
        {
            services.AddTransient<IAlunoQuery, AlunoQuery>();
        }

        private static void RegisterService(IServiceCollection services)
        {
            services.AddTransient<IAlunoService, AlunoService>();            
        }
    }
}
