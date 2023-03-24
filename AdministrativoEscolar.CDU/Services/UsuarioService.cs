using AdministrativoEscolar.CDU.Services.Interfaces;
using AdministrativoEscolar.CORE.DTOs.Request;
using AdministrativoEscolar.CORE.DTOs.Response.Base;
using AdministrativoEscolar.CORE.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministrativoEscolar.CDU.Services
{
    public class UsuarioService : IUsuarioService
    {
        public Task<ResponseDTO> Login(LoginRequestDTO alunoDTO)
        {
            var senhaCrytptografada = Util.CryptoSha512(alunoDTO.TxSenha);

            throw new NotImplementedException();
        }
    }
}
