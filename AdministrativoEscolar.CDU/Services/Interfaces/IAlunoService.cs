using AdministrativoEscolar.CORE.DTOs.Request;
using AdministrativoEscolar.CORE.DTOs.Response.Base;

namespace AdministrativoEscolar.CDU.Services.Interfaces
{
    public interface IAlunoService
    {
        Task<ResponseDTO> Create(AlunoRequestDTO alunoDTO);
        Task<ResponseDTO> Delete(int idAluno);
        Task<ResponseDTO> Update(AlunoRequestDTO alunoDTO);
    }
}
