using AdministrativoEscolar.CORE.DTOs.Request.Aluno;
using AdministrativoEscolar.CORE.DTOs.Response.Base;

namespace AdministrativoEscolar.CDU.Services.Interfaces
{
    public interface IAlunoService
    {
        Task<ResponseDTO> Create(CreateAlunoRequestDTO alunoDTO);
        Task<ResponseDTO> Delete(int idAluno);
        Task<ResponseDTO> Update(UpdateAlunoRequestDTO alunoDTO);
    }
}
