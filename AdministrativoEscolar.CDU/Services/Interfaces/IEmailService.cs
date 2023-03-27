using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministrativoEscolar.CDU.Services.Interfaces
{
    public interface IEmailService
    {
        void EnviarEmail(string email, string cdTipoUsuario);
    }
}
