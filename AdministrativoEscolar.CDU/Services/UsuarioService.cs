using AdministrativoEscolar.CDU.Services.Interfaces;
using AdministrativoEscolar.CORE.Context;
using AdministrativoEscolar.CORE.DTOs.Request;
using AdministrativoEscolar.CORE.DTOs.Response.Base;
using AdministrativoEscolar.CORE.DTOs.Response.Usuario;
using AdministrativoEscolar.CORE.Entities;
using AdministrativoEscolar.CORE.Notification;
using AdministrativoEscolar.CORE.Utils;
using AdministrativoEscolar.CORE.Utils.UserLogged;
using AdministrativoEscolar.READ.Queries.AlunoQ;
using AdministrativoEscolar.READ.Queries.TipoUsuarioQ;
using AdministrativoEscolar.READ.Queries.UsuarioQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministrativoEscolar.CDU.Services
{
    public class UsuarioService : Notificar, IUsuarioService
    {
        private readonly AdmEscolarDbContext _db;
        private readonly IUsuarioQuery _usuarioQuery;

        public UsuarioService(AdmEscolarDbContext context, IUsuarioQuery usuarioQuery, INotificador notificador) : base(notificador)
        {
            _db = context;
            _usuarioQuery = usuarioQuery;
        }

        public async Task<ResponseDTO> Login(LoginRequestDTO loginDTO)
        {
            GenericResponseDTO<TokenResponseDTO> response = new();
            loginDTO.TxSenha = Util.CryptoSha512(loginDTO.TxSenha);

            var resultQuery = await _usuarioQuery.GetLogin(loginDTO);

            if (resultQuery == null)
            {
                NotificarErro("Login ou Senha invalidos");
                return response;
            }

            var result = Util.GeneratedTokenJwt(resultQuery);
            response = new GenericResponseDTO<TokenResponseDTO>(result);

            return response;
        }
    }
}
