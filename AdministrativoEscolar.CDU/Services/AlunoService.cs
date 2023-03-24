using AdministrativoEscolar.CDU.Services.Interfaces;
using AdministrativoEscolar.CORE.Context;
using AdministrativoEscolar.CORE.DTOs.Request.Aluno;
using AdministrativoEscolar.CORE.DTOs.Response.Base;
using AdministrativoEscolar.CORE.Entities;
using AdministrativoEscolar.CORE.Notification;
using AdministrativoEscolar.READ.Queries.AlunoQ;

namespace AdministrativoEscolar.CDU.Services
{
    public class AlunoService : Notificar, IAlunoService
    {
        private readonly AdmEscolarDbContext _db;
        private readonly IAlunoQuery _alunoQuery;

        public AlunoService(AdmEscolarDbContext context, IAlunoQuery alunoQuery, INotificador notificador) : base(notificador)
        {
            _db = context;
            _alunoQuery = alunoQuery;
        }

        public async Task<ResponseDTO> Create(CreateAlunoRequestDTO alunoDTO)
        {
            GenericResponseDTO<Aluno> response = new();

            var existeAluno = _alunoQuery.GetAlunoByCPF(alunoDTO.Aluno!.NuCPF).Result;

            if(existeAluno != null) { 
                NotificarErro("Já existe um aluno cadastrado com esse CPF"); 
                return response; 
            }

            var aluno = new Aluno()
            {
                IdAluno = 0,
                DtNascimento = alunoDTO.Aluno!.DtNascimento,
                NmAluno = alunoDTO.Aluno!.NmAluno,
                NuCPF = alunoDTO.Aluno!.NuCPF,
                NuRG = alunoDTO.Aluno!.NuRG,
                NuTelefone = alunoDTO.Aluno!.NuTelefone,
                SbnmAluno = alunoDTO.Aluno!.SbnmAluno,
                TxNacionalidade = alunoDTO.Aluno!.TxNacionalidade,
                Matricula = new Matricula()
                {
                    IdMatricula = 0,
                    NuMatricula = GerarNuMatricula()
                },
                Enderecos = new List<EnderecoAluno>()
                {
                    new EnderecoAluno()
                    {
                        IdEnderecoAluno = 0,
                        FlEnderecoAtual = true,
                        NuCepEndereco = alunoDTO.Endereco!.NuCepEndereco,
                        NuEndereco = alunoDTO.Endereco!.NuEndereco,
                        TxBairro = alunoDTO.Endereco!.TxBairro,
                        TxCidade = alunoDTO.Endereco!.TxCidade,
                        TxEndereco = alunoDTO.Endereco!.TxEndereco,
                        TxEstado = alunoDTO.Endereco!.TxEstado,
                    }
                },
                Responsaveis = alunoDTO.Responsaveis?.Select(
                    responsavel => new ResponsavelAluno()
                    {
                        IdResponsavelAluno = 0,
                        DtNascimento = responsavel.DtNascimento,
                        FlResponsavelPrincipal = responsavel.FlResponsavelPrincipal,
                        NmResponsavel = responsavel.NmResponsavel,
                        NuCPF = responsavel.NuCPF,
                        NuRG = responsavel.NuRG,
                        NuTelefone = responsavel.NuTelefone
                    }).ToList()                
            };

            _db.Alunos.Add(aluno);

            await _db.SaveChangesAsync();

            response = new GenericResponseDTO<Aluno>(aluno);

            return response; 
        }

        public async Task<ResponseDTO> Delete(int idAluno)
        {
            GenericResponseDTO<Aluno> response = new();

            var aluno = _alunoQuery.GetAlunoById(idAluno).Result;

            if (aluno == null)
            {
                NotificarErro("Esse aluno não existe");
                return response;
            }

            if (aluno.DtCriacao.Date != DateTime.Now.Date)
            {
                NotificarErro("Não foi possível deletar esse aluno.");
                return response;
            }

            aluno.DtDelecao = DateTime.Now;
            _db.Alunos.Update(aluno);

            await _db.SaveChangesAsync();

            response = new GenericResponseDTO<Aluno>(aluno);

            return response;
        }

        public async Task<ResponseDTO> Update(UpdateAlunoRequestDTO alunoDTO)
        {
            GenericResponseDTO<Aluno> response = new();

            var aluno = _alunoQuery.GetAlunoById(alunoDTO.IdAluno).Result;

            if (aluno == null)
            {
                NotificarErro("Esse aluno não existe");
                return response;
            }

            if (aluno.DtCriacao.Date != DateTime.Now.Date &&
                (!aluno.DtNascimento.Equals(alunoDTO.DtNascimento) ||
                 !aluno.NuCPF.Equals(alunoDTO.NuCPF) || 
                 !aluno.NuRG.Equals(alunoDTO.NuRG) ||
                 !aluno.TxNacionalidade.Equals(alunoDTO.TxNacionalidade)))
            {
                NotificarErro("Não foi possível atualizar os dados desse aluno.");
                return response;
            }

            aluno.DtNascimento = alunoDTO.DtNascimento;
            aluno.NmAluno = alunoDTO.NmAluno;
            aluno.NuCPF = alunoDTO.NuCPF;
            aluno.NuRG = alunoDTO.NuRG;
            aluno.NuTelefone = alunoDTO.NuTelefone;
            aluno.SbnmAluno = alunoDTO.SbnmAluno;
            aluno.TxNacionalidade = alunoDTO.TxNacionalidade;

            _db.Alunos.Update(aluno);

            await _db.SaveChangesAsync();

            response = new GenericResponseDTO<Aluno>(aluno);

            return response;
        }

        private string GerarNuMatricula()
        {
            var quantidadeAlunos = _alunoQuery.QuantidadeAlunos().Result + 1;
            var data = DateTime.Now.Year.ToString();
            return data + quantidadeAlunos.ToString().PadLeft(5, '0');
        }


    }
}
