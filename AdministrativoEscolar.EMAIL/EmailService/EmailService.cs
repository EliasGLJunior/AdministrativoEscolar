using AdministrativoEscolar.EMAIL.Model;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;
using System.Text;

namespace AdministrativoEscolar.EMAIL.EmailService
{
    public class EmailService : IEmailService
    {
        #region Intialize
        private readonly SmtpConfiguration _smtpConfig;
        private readonly ILogger<EmailService> _logger;

        public EmailService(IOptions<SmtpConfiguration> smtpConfig,
                                  ILogger<EmailService> logger)
        {
            _logger = logger;
            _smtpConfig = smtpConfig.Value;
        }
        #endregion


        public async Task<EmailSendResult> SendEmailAsync(string serializedMessage)
        {
            MimeMessage message;
            var messageBytes = Encoding.UTF8.GetBytes(serializedMessage);
            using (var stream = new MemoryStream(messageBytes))
            {
                message = await MimeMessage.LoadAsync(stream);
            }

            var result = new EmailSendResult();

            var cancellationToken = new CancellationTokenSource(TimeSpan.FromSeconds(30)).Token;
            try
            {
                var messageFrom = new InternetAddressList
                {
                    new MailboxAddress(Encoding.UTF8, _smtpConfig.SenderName, _smtpConfig.SenderEmail)
                };
                var newMessage = new MimeMessage(messageFrom, message.To, message.Subject, message.Body);

                using (var client = new SmtpClient())
                {
                    var securityOptions = _smtpConfig.EnableSsl
                        ? SecureSocketOptions.StartTls
                        : SecureSocketOptions.None;
                    await client.ConnectAsync(_smtpConfig.Host, _smtpConfig.Port, securityOptions, cancellationToken);

                    await client.AuthenticateAsync(_smtpConfig.SenderEmail, _smtpConfig.Password, cancellationToken);

                    await client.SendAsync(newMessage, cancellationToken);
                    await client.DisconnectAsync(true, cancellationToken);
                }

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao enviar email");
                return result with { Error = ex.Message };
            }
        }
    }
}
