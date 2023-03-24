using AdministrativoEscolar.CORE.DTOs.Response.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministrativoEscolar.CORE.DTOs.Response.Usuario
{
    public class LoginResponseDTO : ResponseDTO
    {
        public int IdUsuario { get; set; }
        public string CdTipoUsuario { get; set; } = string.Empty;
        public string TxTipoUsuario { get; set; } = string.Empty;
        public int IdEscola { get; set; } = 0;
        public int IdAluno { get; set; } = 0;
        public string NmAluno { get; set; } = string.Empty;
        public string SbnmAluno { get; set; } = string.Empty;
    }
}
