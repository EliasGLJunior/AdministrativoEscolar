using AdministrativoEscolar.CDU.Services;
using AdministrativoEscolar.CDU.Services.Interfaces;
using AdministrativoEscolar.CORE.Notification;
using AdministrativoEscolar.CORE.Utils.UserLogged;
using AdministrativoEscolar.EMAIL.EmailService;
using AdministrativoEscolar.EMAIL.Model;
using AdministrativoEscolar.READ.Queries.AlunoQ;
using AdministrativoEscolar.READ.Queries.StatusMatriculaQ;
using AdministrativoEscolar.READ.Queries.StatusUsuarioQ;
using AdministrativoEscolar.READ.Queries.TipoUsuarioQ;
using AdministrativoEscolar.READ.Queries.UsuarioQ;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace AdministrativoEscolar.API.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            RegisterExtensions(services);
            RegisterNotification(services);
            RegisterQuery(services);
            RegisterService(services);

            services.Configure<SmtpConfiguration>(configuration.GetSection(nameof(SmtpConfiguration)));

            return services;
        }

        private static void RegisterNotification(IServiceCollection services)
        {
            services.AddScoped<INotificador, Notificador>();
        }

        private static void RegisterQuery(IServiceCollection services)
        {
            services.AddTransient<IAlunoQuery, AlunoQuery>();
            services.AddTransient<IStatusMatriculaQuery, StatusMatriculaQuery>();
            services.AddTransient<IStatusUsuarioQuery, StatusUsuarioQuery>();
            services.AddTransient<ITipoUsuarioQuery, TipoUsuarioQuery>();
            services.AddTransient<IUsuarioQuery, UsuarioQuery>();
        }

        private static void RegisterService(IServiceCollection services)
        {
            services.AddTransient<IAlunoService, AlunoService>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<ISendEmailService, SendEmailService>();
            services.AddTransient<IUsuarioService, UsuarioService>();
        }

        private static void RegisterExtensions(IServiceCollection services)
        {
            services.AddTransient<IUserLoggedExtensions, UserLoggedExtensions>();

            services.AddHttpContextAccessor();
        }
    }
}
