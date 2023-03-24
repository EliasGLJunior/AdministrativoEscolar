using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministrativoEscolar.CORE.DTOs.Request
{
    public class LoginRequestDTO
    {
        public string TxLogin { get; set; } = string.Empty;
        public string TxSenha { get; set; } = string.Empty;
    }
}
