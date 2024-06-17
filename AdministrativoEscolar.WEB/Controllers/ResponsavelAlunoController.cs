using AdministrativoEscolar.API.Controllers.Base;
using AdministrativoEscolar.CDU.Services.Interfaces;
using AdministrativoEscolar.CORE.DTOs.Request.ResponsavelAluno;
using AdministrativoEscolar.CORE.DTOs.Response.Base;
using AdministrativoEscolar.CORE.Notification;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AdministrativoEscolar.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class ResponsavelAlunoController : BaseController
    {
        private readonly IResponsavelAlunoService _enderecoService;
        public ResponsavelAlunoController(IResponsavelAlunoService enderecoService, INotificador notificador) : base(notificador)
        {
            _enderecoService = enderecoService;
        }

        [SwaggerResponse(statusCode: 200)]
        [SwaggerResponse(statusCode: 400)]
        [SwaggerResponse(statusCode: 401)]
        [SwaggerResponse(statusCode: 403)]
        [SwaggerResponse(statusCode: 500)]
        [HttpPost("CreateResponsavel")]
        public async Task<ActionResult> Create(CreateResponsavelAlunoRequestDTO enderecoDTO)
        {
            ResponseDTO response = await _enderecoService.Create(enderecoDTO);
            return CustomResponse(response);
        }

        [SwaggerResponse(statusCode: 200)]
        [SwaggerResponse(statusCode: 400)]
        [SwaggerResponse(statusCode: 401)]
        [SwaggerResponse(statusCode: 403)]
        [SwaggerResponse(statusCode: 500)]
        [HttpPatch("DeleteResponsavel")]
        public async Task<ActionResult> Delete(int idResponsavel)
        {
            ResponseDTO response = await _enderecoService.Delete(idResponsavel);
            return CustomResponse(response);
        }

        [SwaggerResponse(statusCode: 200)]
        [SwaggerResponse(statusCode: 400)]
        [SwaggerResponse(statusCode: 401)]
        [SwaggerResponse(statusCode: 403)]
        [SwaggerResponse(statusCode: 500)]
        [HttpPatch("UpdateResponsavel")]
        public async Task<ActionResult> Update(UpdateResponsavelAlunoRequestDTO enderecoDTO)
        {
            ResponseDTO response = await _enderecoService.Update(enderecoDTO);
            return CustomResponse(response);
        }
    }
}
