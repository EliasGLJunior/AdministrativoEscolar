using AdministrativoEscolar.CDU.Services.Interfaces;
using AdministrativoEscolar.CORE.DTOs.Request;
using AdministrativoEscolar.CORE.DTOs.Response.Base;
using Microsoft.AspNetCore.Mvc;

namespace AdministrativoEscolar.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : Controller
    {
        private readonly IAlunoService _alunoService;
        public AlunoController(IAlunoService alunoService)
        {
            _alunoService = alunoService;
        }

        [HttpPost]
        public async Task<ResponseDTO> Create(AlunoRequestDTO alunoDTO)
        {
            return await _alunoService.Create(alunoDTO);
        }
    }
}