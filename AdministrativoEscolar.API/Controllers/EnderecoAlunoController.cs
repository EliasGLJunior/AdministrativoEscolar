using AdministrativoEscolar.API.Controllers.Base;
using AdministrativoEscolar.CDU.Services.Interfaces;
using AdministrativoEscolar.CORE.DTOs.Request.EnderecoAluno;
using AdministrativoEscolar.CORE.DTOs.Response.Base;
using AdministrativoEscolar.CORE.Notification;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AdministrativoEscolar.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class EnderecoAlunoController : BaseController
    {
        private readonly IEnderecoAlunoService _enderecoService;
        public EnderecoAlunoController(IEnderecoAlunoService enderecoService, INotificador notificador) : base(notificador)
        {
            _enderecoService = enderecoService;
        }

        [SwaggerResponse(statusCode: 200)]
        [SwaggerResponse(statusCode: 400)]
        [SwaggerResponse(statusCode: 401)]
        [SwaggerResponse(statusCode: 403)]
        [SwaggerResponse(statusCode: 500)]
        [HttpPost("CreateEndereco")]
        public async Task<ActionResult> Create(CreateEnderecoAlunoRequestDTO enderecoDTO)
        {
            ResponseDTO response = await _enderecoService.Create(enderecoDTO);
            return CustomResponse(response);
        }

        [SwaggerResponse(statusCode: 200)]
        [SwaggerResponse(statusCode: 400)]
        [SwaggerResponse(statusCode: 401)]
        [SwaggerResponse(statusCode: 403)]
        [SwaggerResponse(statusCode: 500)]
        [HttpPatch("DeleteEndereco")]
        public async Task<ActionResult> Delete(int idEndereco)
        {
            ResponseDTO response = await _enderecoService.Delete(idEndereco);
            return CustomResponse(response);
        }

        [SwaggerResponse(statusCode: 200)]
        [SwaggerResponse(statusCode: 400)]
        [SwaggerResponse(statusCode: 401)]
        [SwaggerResponse(statusCode: 403)]
        [SwaggerResponse(statusCode: 500)]
        [HttpPatch("UpdateEndereco")]
        public async Task<ActionResult> Update(UpdateEnderecoAlunoRequestDTO enderecoDTO)
        {
            ResponseDTO response = await _enderecoService.Update(enderecoDTO);
            return CustomResponse(response);
        }
    }
}
