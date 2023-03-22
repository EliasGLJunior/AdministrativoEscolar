using AdministrativoEscolar.CDU.Services.Interfaces;
using AdministrativoEscolar.CORE.Context;
using AdministrativoEscolar.CORE.DTOs.Request;
using AdministrativoEscolar.CORE.DTOs.Response.Base;
using AdministrativoEscolar.CORE.Entities;

namespace AdministrativoEscolar.CDU.Services
{
    public class AlunoService : IAlunoService
    {
        private readonly AdmEscolarDbContext _db;

        public AlunoService(AdmEscolarDbContext context)
        {
            _db = context;
        }

        public async Task<ResponseDTO> Create(AlunoRequestDTO alunoDTO)
        {
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
                    NuMatricula = "AAA"
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

            var res = new GenericResponseDTO<Aluno>(aluno);

            return res; 
        }

        public async Task<ResponseDTO> Delete(int idAluno)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDTO> Update(AlunoRequestDTO alunoDTO)
        {
            throw new NotImplementedException();
        }
    }
}
