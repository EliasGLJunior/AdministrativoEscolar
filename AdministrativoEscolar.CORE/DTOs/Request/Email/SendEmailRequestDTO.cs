using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministrativoEscolar.CORE.DTOs.Request.Email
{
    public class SendEmailRequestDTO
    {
        public List<EmailsDTO>? DestinationEmail { get; set; }
        public List<string>? CC { get; set; }
        public string Subject { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public List<ArchiveEmailDTO>? Archives { get; set; }
    }
}
