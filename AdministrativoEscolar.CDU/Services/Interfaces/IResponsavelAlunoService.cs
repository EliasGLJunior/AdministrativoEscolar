using AdministrativoEscolar.CORE.DTOs.Request.ResponsavelAluno;
using AdministrativoEscolar.CORE.DTOs.Response.Base;

namespace AdministrativoEscolar.CDU.Services.Interfaces
{
    public interface IResponsavelAlunoService
    {
        Task<ResponseDTO> Create(CreateResponsavelAlunoRequestDTO responsavelDTO);
        Task<ResponseDTO> Delete(int idResponsavel);
        Task<ResponseDTO> Update(UpdateResponsavelAlunoRequestDTO responsavelDTO);
    }
}
