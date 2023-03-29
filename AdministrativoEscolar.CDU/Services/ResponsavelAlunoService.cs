using AdministrativoEscolar.CDU.Services.Interfaces;
using AdministrativoEscolar.CORE.Context;
using AdministrativoEscolar.CORE.DTOs.Request.Aluno;
using AdministrativoEscolar.CORE.DTOs.Request.ResponsavelAluno;
using AdministrativoEscolar.CORE.DTOs.Response.Base;
using AdministrativoEscolar.CORE.Entities;
using AdministrativoEscolar.CORE.Notification;
using AdministrativoEscolar.CORE.Utils;
using AdministrativoEscolar.CORE.Utils.UserLogged;
using AdministrativoEscolar.READ.Queries.AlunoQ;
using AdministrativoEscolar.READ.Queries.MatriculaQ;
using AdministrativoEscolar.READ.Queries.ResponsavelAlunoQ;
using AdministrativoEscolar.READ.Queries.StatusUsuarioQ;
using AdministrativoEscolar.READ.Queries.TipoUsuarioQ;

namespace AdministrativoEscolar.CDU.Services
{
    public class ResponsavelAlunoService : Notificar, IResponsavelAlunoService
    {
        private readonly AdmEscolarDbContext _db;
        private readonly IMatriculaQuery _matriculaQuery;
        private readonly IResponsavelAlunoQuery _responsavelQuery;
        private readonly IStatusUsuarioQuery _statusUsuarioQuery;
        private readonly ITipoUsuarioQuery _tipoUsuarioQuery;
        private readonly IUserLoggedExtensions _userLoggedExtensions;

        public ResponsavelAlunoService(
            AdmEscolarDbContext context,
            IMatriculaQuery matriculaQuery,
            IResponsavelAlunoQuery responsavelQuery,
            IStatusUsuarioQuery statusUsuarioQuery,
            ITipoUsuarioQuery tipoUsuarioQuery,
            IUserLoggedExtensions userLoggedExtensions,
            INotificador notificador) : base(notificador)
        {
            _db = context;
            _matriculaQuery = matriculaQuery;
            _responsavelQuery = responsavelQuery;
            _statusUsuarioQuery = statusUsuarioQuery;
            _tipoUsuarioQuery = tipoUsuarioQuery;
            _userLoggedExtensions = userLoggedExtensions;
        }

        public async Task<ResponseDTO> Create(CreateResponsavelAlunoRequestDTO responsavelDTO)
        {
            GenericResponseDTO<ResponsavelAluno> response = new();

            var existeResponsavel = _responsavelQuery.GetResponsavelByIdAluno(responsavelDTO.IdAluno).Result;

            if (existeResponsavel != null)
            {
                NotificarErro("Já existe um endereço ativo para esse Aluno.");
                return response;
            }

            string nuMatricula = _matriculaQuery.GetNuMatriculaByIdAluno(responsavelDTO.IdAluno).Result;
            int idEscola = _userLoggedExtensions.getIdEscola();

            ResponsavelAluno responsavel = new ResponsavelAluno()
            {
                IdResponsavelAluno = 0,
                IdAluno = responsavelDTO.IdAluno,
                NmResponsavel = responsavelDTO.NmResponsavel,
                NuCPF = responsavelDTO.NuCPF,
                NuRG = responsavelDTO.NuRG,
                FlResponsavelPrincipal = responsavelDTO.FlResponsavelPrincipal,
                DtNascimento = responsavelDTO.DtNascimento,
                NuTelefone = responsavelDTO.NuTelefone,
                Usuario = new Usuario()
                {
                    IdEscola = idEscola,
                    IdTipoUsuario = _tipoUsuarioQuery.GetIdByCdTipoUsuario("responsavel_aluno").Result,
                    IdUsuario = 0,
                    TxEmail = responsavelDTO.TxEmail,
                    TxSenha = Util.CryptoSha512(nuMatricula + responsavelDTO!.NuCPF.Take(3) + responsavelDTO!.NuRG.Take(2)),
                    Historico = new List<StatusUsuarioHistorico>()
                    {
                        new StatusUsuarioHistorico()
                        {
                            IdStatusUsuario = _statusUsuarioQuery.GetIdByCdStatusUsuario("pendente").Result,
                            FlStatusAtual = true
                        }
                    }
                }
            };

            _db.ResponsavelAlunos.Add(responsavel);

            await _db.SaveChangesAsync();

            response = new GenericResponseDTO<ResponsavelAluno>(responsavel);

            return response;
        }

        public async Task<ResponseDTO> Delete(int idResponsavel)
        {
            GenericResponseDTO<ResponsavelAluno> response = new();

            var responsavel = _responsavelQuery.GetResponsavelById(idResponsavel).Result;

            if (responsavel == null)
            {
                NotificarErro("Esse responsável não existe");
                return response;
            }

            if (responsavel.DtCriacao.Date != DateTime.Now.Date)
            {
                NotificarErro("Não foi possível deletar esse responsável.");
                return response;
            }

            responsavel.DtDelecao = DateTime.Now;
            _db.ResponsavelAlunos.Update(responsavel);

            await _db.SaveChangesAsync();

            response = new GenericResponseDTO<ResponsavelAluno>(responsavel);

            return response;
        }

        public async Task<ResponseDTO> Update(UpdateResponsavelAlunoRequestDTO responsavelDTO)
        {
            GenericResponseDTO<ResponsavelAluno> response = new();

            var responsavel = _responsavelQuery.GetResponsavelById(responsavelDTO.IdResponsavel).Result;

            if (responsavel == null)
            {
                NotificarErro("Esse responsável não existe");
                return response;
            }

            if (responsavel.DtCriacao.Date != DateTime.Now.Date &&
                (!responsavel.NuCPF.Equals(responsavelDTO.NuCPF) ||
                 !responsavel.NuRG.Equals(responsavelDTO.NuRG) ||
                 !responsavel.DtNascimento.Equals(responsavelDTO.DtNascimento)))
            {
                NotificarErro("Não foi possível atualizar os dados desse responsável.");
                return response;
            }

            responsavel.NuRG = responsavelDTO.NuRG;
            responsavel.NuCPF = responsavelDTO.NuCPF;
            responsavel.NmResponsavel = responsavelDTO.NmResponsavel;
            responsavel.DtNascimento = responsavelDTO.DtNascimento;
            responsavel.FlResponsavelPrincipal = responsavelDTO.FlResponsavelPrincipal;
            responsavel.NuTelefone = responsavelDTO.NuTelefone;

            _db.ResponsavelAlunos.Update(responsavel);

            await _db.SaveChangesAsync();

            response = new GenericResponseDTO<ResponsavelAluno>(responsavel);

            return response;
        }
    }
}
