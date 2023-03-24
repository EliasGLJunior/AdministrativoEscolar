using AdministrativoEscolar.API.Controllers.Base;
using AdministrativoEscolar.CDU.Services.Interfaces;
using AdministrativoEscolar.CORE.DTOs.Request.Aluno;
using AdministrativoEscolar.CORE.DTOs.Response.Base;
using AdministrativoEscolar.CORE.Notification;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel;

namespace AdministrativoEscolar.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class AlunoController : BaseController
    {
        private readonly IAlunoService _alunoService;
        public AlunoController(IAlunoService alunoService, INotificador notificador) : base(notificador) 
        {
            _alunoService = alunoService;
        }

        [SwaggerResponse(statusCode: 200)]
        [SwaggerResponse(statusCode: 400)]
        [SwaggerResponse(statusCode: 401)]
        [SwaggerResponse(statusCode: 403)]
        [SwaggerResponse(statusCode: 500)]
        [HttpPost("CreateAluno")]
        public async Task<ActionResult> Create(CreateAlunoRequestDTO alunoDTO)
        {
            ResponseDTO response = await _alunoService.Create(alunoDTO);
            return CustomResponse(response);
        }

        [SwaggerResponse(statusCode: 200)]
        [SwaggerResponse(statusCode: 400)]
        [SwaggerResponse(statusCode: 401)]
        [SwaggerResponse(statusCode: 403)]
        [SwaggerResponse(statusCode: 500)]
        [HttpPatch("DeleteAluno")]
        public async Task<ActionResult> Delete(int idAluno)
        {
            ResponseDTO response = await _alunoService.Delete(idAluno);
            return CustomResponse(response);
        }

        [SwaggerResponse(statusCode: 200)]
        [SwaggerResponse(statusCode: 400)]
        [SwaggerResponse(statusCode: 401)]
        [SwaggerResponse(statusCode: 403)]
        [SwaggerResponse(statusCode: 500)]
        [HttpPatch("UpdateAluno")]
        public async Task<ActionResult> Update(UpdateAlunoRequestDTO alunoDTO)
        {
            ResponseDTO response = await _alunoService.Update(alunoDTO);
            return CustomResponse(response);
        }
    }
}