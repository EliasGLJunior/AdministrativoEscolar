using AdministrativoEscolar.EMAIL.Model;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministrativoEscolar.EMAIL.EmailService
{
    public interface ISendEmailService
    {
        Task<EmailSendResult> SendEmailAsync(string serializedMessage);
    }
}
