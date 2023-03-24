using AdministrativoEscolar.CORE.DTOs.Request;
using AdministrativoEscolar.CORE.DTOs.Request.Aluno;
using AdministrativoEscolar.CORE.DTOs.Response.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministrativoEscolar.CDU.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<ResponseDTO> Login(LoginRequestDTO alunoDTO);
    }
}
