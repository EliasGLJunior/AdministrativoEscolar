using AdministrativoEscolar.CORE.DTOs.Response.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministrativoEscolar.CORE.DTOs.Response.Usuario
{
    public class TokenResponseDTO : ResponseDTO
    {
        public string Token { get; set; } = string.Empty;
    }
}
