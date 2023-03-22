using AdministrativoEscolar.CDU.Services;
using AdministrativoEscolar.CDU.Services.Interfaces;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace AdministrativoEscolar.API.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
           
            RegisterService(services);

            return services;
        }

        private static void RegisterService(IServiceCollection services)
        {
            services.AddTransient<IAlunoService, AlunoService>();            
        }
    }
}
