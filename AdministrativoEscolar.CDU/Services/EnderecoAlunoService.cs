using AdministrativoEscolar.CDU.Services.Interfaces;
using AdministrativoEscolar.CORE.Context;
using AdministrativoEscolar.CORE.DTOs.Request.EnderecoAluno;
using AdministrativoEscolar.CORE.DTOs.Response.Base;
using AdministrativoEscolar.CORE.Entities;
using AdministrativoEscolar.CORE.Notification;
using AdministrativoEscolar.READ.Queries.EnderecoQ;

namespace AdministrativoEscolar.CDU.Services
{
    public class EnderecoAlunoService : Notificar, IEnderecoAlunoService
    {
        private readonly AdmEscolarDbContext _db;
        private readonly IEnderecoAlunoQuery _enderecoQuery;

        public EnderecoAlunoService(
            AdmEscolarDbContext context,
            IEnderecoAlunoQuery enderecoQuery,
            INotificador notificador) : base(notificador)
        {
            _db = context;
            _enderecoQuery = enderecoQuery;
        }

        public async Task<ResponseDTO> Create(CreateEnderecoAlunoRequestDTO enderecoDTO)
        {
            GenericResponseDTO<EnderecoAluno> response = new();

            var existeEndereco = _enderecoQuery.GetEnderecoByIdAluno(enderecoDTO.IdAluno).Result;

            if (existeEndereco != null)
            {
                NotificarErro("Já existe um endereço ativo para esse Aluno.");
                return response;
            }
            EnderecoAluno endereco = new EnderecoAluno()
            {
                IdEnderecoAluno = 0,
                IdAluno = enderecoDTO.IdAluno,
                NuEndereco = enderecoDTO.NuEndereco,
                NuCepEndereco = enderecoDTO.NuCepEndereco,
                TxBairro = enderecoDTO.TxBairro,
                TxCidade = enderecoDTO.TxCidade,
                TxEndereco = enderecoDTO.TxEndereco,
                TxEstado = enderecoDTO.TxEstado,
                FlEnderecoAtual = true
            };

            _db.EnderecoAlunos.Add(endereco);

            await _db.SaveChangesAsync();

            response = new GenericResponseDTO<EnderecoAluno>(endereco);

            return response;
        }

        public async Task<ResponseDTO> Delete(int idEndereco)
        {
            GenericResponseDTO<EnderecoAluno> response = new();

            var endereco = _enderecoQuery.GetEnderecoById(idEndereco).Result;

            if (endereco == null)
            {
                NotificarErro("Esse endereço não existe");
                return response;
            }

            if (endereco.DtCriacao.Date != DateTime.Now.Date)
            {
                NotificarErro("Não foi possível deletar esse endereço.");
                return response;
            }

            endereco.DtDelecao = DateTime.Now;
            _db.EnderecoAlunos.Update(endereco);

            await _db.SaveChangesAsync();

            response = new GenericResponseDTO<EnderecoAluno>(endereco);

            return response;
        }

        public async Task<ResponseDTO> Update(UpdateEnderecoAlunoRequestDTO enderecoDTO)
        {
            GenericResponseDTO<EnderecoAluno> response = new();

            var endereco = _enderecoQuery.GetEnderecoById(enderecoDTO.IdEndereco).Result;

            if (endereco == null)
            {
                NotificarErro("Esse endereço não existe");
                return response;
            }

            if (endereco.DtCriacao.Date != DateTime.Now.Date &&
                (!endereco.NuCepEndereco.Equals(enderecoDTO.NuCepEndereco) ||
                 !endereco.NuEndereco.Equals(enderecoDTO.NuEndereco)))
            {
                NotificarErro("Não foi possível atualizar os dados desse endereço.");
                return response;
            }

            endereco.NuEndereco = enderecoDTO.NuEndereco;
            endereco.NuCepEndereco = enderecoDTO.NuCepEndereco;
            endereco.TxBairro = enderecoDTO.TxBairro;
            endereco.TxCidade = enderecoDTO.TxCidade;
            endereco.TxEndereco = enderecoDTO.TxEndereco;
            endereco.TxEstado = enderecoDTO.TxEstado;
            endereco.FlEnderecoAtual = enderecoDTO.FlEnderecoAtual;

            _db.EnderecoAlunos.Update(endereco);

            await _db.SaveChangesAsync();

            response = new GenericResponseDTO<EnderecoAluno>(endereco);

            return response;
        }
    }
}
