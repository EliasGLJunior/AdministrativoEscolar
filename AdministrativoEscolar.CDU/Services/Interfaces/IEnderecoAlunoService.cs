using AdministrativoEscolar.CORE.DTOs.Request.EnderecoAluno;
using AdministrativoEscolar.CORE.DTOs.Response.Base;

namespace AdministrativoEscolar.CDU.Services.Interfaces
{
    public interface IEnderecoAlunoService
    {
        Task<ResponseDTO> Create(CreateEnderecoAlunoRequestDTO enderecoDTO);
        Task<ResponseDTO> Delete(int idEndereco);
        Task<ResponseDTO> Update(UpdateEnderecoAlunoRequestDTO enderecoDTO);
    }
}
