using AdministrativoEscolar.CDU.Services.Interfaces;
using AdministrativoEscolar.CORE.DTOs.Request.Email;
using AdministrativoEscolar.CORE.Utils;
using AdministrativoEscolar.EMAIL.EmailService;

namespace AdministrativoEscolar.CDU.Services
{
    public class EmailService : IEmailService
    {
        private readonly ISendEmailService _sendEmailService;

        public EmailService(ISendEmailService sendEmailService)
        {
            _sendEmailService = sendEmailService;
        }
        public void EnviarEmail(string email, string cdTipoUsuario)
        {
            //Fazer Templates e validar cdTipoUsuario para utilizar template certo
            var emailRequest = new SendEmailRequestDTO()
            {
                DestinationEmail = new List<EmailsDTO>() { new EmailsDTO() { Email = email } },
                Body = "Bem Vindo",
                Subject = "Bem Vindo",
                Archives = new List<ArchiveEmailDTO>(),
                CC = new List<string>()
            };

            var serializedEmail = Util.MountEmail(emailRequest).Result;

            _sendEmailService.SendEmailAsync(serializedEmail);
        }
    }
}
