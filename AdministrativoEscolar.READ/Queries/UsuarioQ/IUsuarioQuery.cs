using AdministrativoEscolar.CORE.DTOs.Request;
using AdministrativoEscolar.CORE.DTOs.Response.Usuario;
using AdministrativoEscolar.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministrativoEscolar.READ.Queries.UsuarioQ
{
    public interface IUsuarioQuery
    {
        Task<TokenResponseDTO> GetLogin(LoginRequestDTO loginDTO);
    }
}
