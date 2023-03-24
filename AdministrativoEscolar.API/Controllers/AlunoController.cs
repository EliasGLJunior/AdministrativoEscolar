using AdministrativoEscolar.API.Controllers.Base;
using AdministrativoEscolar.CDU.Services.Interfaces;
using AdministrativoEscolar.CORE.DTOs.Request.Aluno;
using AdministrativoEscolar.CORE.DTOs.Response.Base;
using AdministrativoEscolar.CORE.Notification;
using Microsoft.AspNetCore.Mvc;

namespace AdministrativoEscolar.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : BaseController
    {
        private readonly IAlunoService _alunoService;
        public AlunoController(IAlunoService alunoService, INotificador notificador) : base(notificador) 
        {
            _alunoService = alunoService;
        }

        [HttpPost("CreateAluno")]
        public async Task<ActionResult> Create(CreateAlunoRequestDTO alunoDTO)
        {
            ResponseDTO response = await _alunoService.Create(alunoDTO);
            return CustomResponse(response);
        }

        [HttpPatch("DeleteAluno")]
        public async Task<ActionResult> Delete(int idAluno)
        {
            ResponseDTO response = await _alunoService.Delete(idAluno);
            return CustomResponse(response);
        }

        [HttpPatch("UpdateAluno")]
        public async Task<ActionResult> Update(UpdateAlunoRequestDTO alunoDTO)
        {
            ResponseDTO response = await _alunoService.Update(alunoDTO);
            return CustomResponse(response);
        }
    }
}