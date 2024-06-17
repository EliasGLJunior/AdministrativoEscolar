using AdministrativoEscolar.API.Controllers.Base;
using AdministrativoEscolar.CDU.Services.Interfaces;
using AdministrativoEscolar.CORE.DTOs.Request;
using AdministrativoEscolar.CORE.DTOs.Request.Aluno;
using AdministrativoEscolar.CORE.DTOs.Response.Base;
using AdministrativoEscolar.CORE.Notification;
using AdministrativoEscolar.READ.Queries.UsuarioQ;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AdministrativoEscolar.API.Controllers
{    
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : BaseController
    {
        private readonly IUsuarioQuery _usuarioQuery;
        public UsuarioController(IUsuarioQuery usuarioQuery, INotificador notificador) : base(notificador)
        {
            _usuarioQuery = usuarioQuery;
        }

        [SwaggerResponse(statusCode: 200)]
        [SwaggerResponse(statusCode: 400)]
        [SwaggerResponse(statusCode: 500)]
        [HttpPost("Login")]
        public async Task<ActionResult> Login(LoginRequestDTO loginDTO)
        {
            ResponseDTO response = await _usuarioQuery.GetLogin(loginDTO);
            return CustomResponse(response);
        }   
    }
}
