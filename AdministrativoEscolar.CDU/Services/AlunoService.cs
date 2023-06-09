﻿using AdministrativoEscolar.CDU.Services.Interfaces;
using AdministrativoEscolar.CORE.Context;
using AdministrativoEscolar.CORE.DTOs.Request.Aluno;
using AdministrativoEscolar.CORE.DTOs.Response.Base;
using AdministrativoEscolar.CORE.Entities;
using AdministrativoEscolar.CORE.Notification;
using AdministrativoEscolar.CORE.Utils;
using AdministrativoEscolar.CORE.Utils.UserLogged;
using AdministrativoEscolar.READ.Queries.AlunoQ;
using AdministrativoEscolar.READ.Queries.StatusMatriculaQ;
using AdministrativoEscolar.READ.Queries.StatusUsuarioQ;
using AdministrativoEscolar.READ.Queries.TipoUsuarioQ;
using Microsoft.EntityFrameworkCore.Storage;

namespace AdministrativoEscolar.CDU.Services
{
    public class AlunoService : Notificar, IAlunoService
    {
        IDbContextTransaction transaction;
        private readonly AdmEscolarDbContext _db;
        private readonly IAlunoQuery _alunoQuery;
        private readonly IStatusMatriculaQuery _statusMatriculaQuery;
        private readonly IStatusUsuarioQuery _statusUsuarioQuery;
        private readonly ITipoUsuarioQuery _tipoUsuarioQuery;
        private readonly IEmailService _emailService;
        private readonly IUserLoggedExtensions _userLoggedExtensions;

        public AlunoService(
            AdmEscolarDbContext context, 
            IAlunoQuery alunoQuery,
            IStatusMatriculaQuery statusMatriculaQuery,
            IStatusUsuarioQuery statusUsuarioQuery,
            ITipoUsuarioQuery tipoUsuarioQuery, 
            IEmailService emailService, 
            IUserLoggedExtensions userLoggedExtensions, 
            INotificador notificador) : base(notificador)
        {
            _db = context;
            _alunoQuery = alunoQuery;
            _statusMatriculaQuery = statusMatriculaQuery;
            _statusUsuarioQuery = statusUsuarioQuery;
            _tipoUsuarioQuery = tipoUsuarioQuery;
            _emailService = emailService;
            _userLoggedExtensions = userLoggedExtensions;
        }

        public async Task<ResponseDTO> Create(CreateAlunoRequestDTO alunoDTO)
        {
            GenericResponseDTO<Aluno> response = new();
            try
            {
                transaction = _db.Database.BeginTransaction();
                var existeAluno = _alunoQuery.GetAlunoByCPF(alunoDTO.Aluno!.NuCPF).Result;

                if (existeAluno != null)
                {
                    RollbackWithError("Já existe um aluno cadastrado com esse CPF");
                    return response;
                }

                string nuMatricula = GerarNuMatricula();
                int idEscola = _userLoggedExtensions.getIdEscola();
                int statusUsuarioId = _statusUsuarioQuery.GetIdByCdStatusUsuario("pendente").Result;

                var aluno = new Aluno()
                {
                    IdAluno = 0,
                    IdEscola = idEscola,
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
                        NuMatricula = nuMatricula,
                        Historico = new List<StatusMatriculaHistorico>()
                        {
                            new StatusMatriculaHistorico()
                            {
                                FlStatusAtual = true,
                                IdStatusMatricula = _statusMatriculaQuery.GetIdByCdStatusMatricula("pendente").Result
                            }
                        }
                    },
                    Usuario = new Usuario()
                    {
                        IdUsuario = 0,
                        IdEscola = idEscola,
                        IdTipoUsuario = _tipoUsuarioQuery.GetIdByCdTipoUsuario("aluno").Result,
                        TxEmail = alunoDTO.Aluno.TxEmail,
                        TxSenha = Util.CryptoSha512(nuMatricula + alunoDTO.Aluno!.NuCPF.Take(3) + alunoDTO.Aluno!.NuRG.Take(2)),
                        Historico = new List<StatusUsuarioHistorico>()
                        {
                            new StatusUsuarioHistorico()
                            {
                                IdStatusUsuario = statusUsuarioId,
                                FlStatusAtual = true
                            }
                        }
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
                            NuTelefone = responsavel.NuTelefone,
                            Usuario = responsavel.FlResponsavelPrincipal ? new Usuario()
                            {
                                IdUsuario = 0,
                                IdEscola = idEscola,
                                IdTipoUsuario = _tipoUsuarioQuery.GetIdByCdTipoUsuario("responsavel_aluno").Result,
                                TxEmail = responsavel.TxEmail,
                                TxSenha = Util.CryptoSha512(nuMatricula + responsavel!.NuCPF.Take(3) + responsavel!.NuRG.Take(2)),
                                Historico = new List<StatusUsuarioHistorico>()
                                {
                                    new StatusUsuarioHistorico()
                                    {
                                        IdStatusUsuario = statusUsuarioId,
                                        FlStatusAtual = true
                                    }
                                }
                            } : null
                        }).ToList(),
                    StatusLetivoHistorico = new List<AlunoStatusLetivoHistorico>()
                    {
                        new AlunoStatusLetivoHistorico()
                        {
                            FlStatusAtual = true,
                            IdStatusLetivo = alunoDTO.Aluno.IdStatusLetivo
                        }
                    }
                };

                string emailResponsavelPrincipal = alunoDTO.Responsaveis!.Where(r => r.FlResponsavelPrincipal).Select(r => r.TxEmail).FirstOrDefault()!;

                _emailService.EnviarEmail(alunoDTO.Aluno.TxEmail, "aluno");
                _emailService.EnviarEmail(emailResponsavelPrincipal, "responsavel_aluno");

                _db.Alunos.Add(aluno);

                await _db.SaveChangesAsync();

                response = new GenericResponseDTO<Aluno>(aluno);

                transaction.Commit();

                return response;
            }
            catch (Exception ex)
            {
                RollbackWithError("AVISO: Ocorreu um erro ao cadastrar um Aluno: " + ex.Message);
                return response;
            }
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
            var ano = DateTime.Now.Year.ToString();
            return ano + "A" + quantidadeAlunos.ToString().PadLeft(5, '0');
        }

        private void RollbackWithError(string error)
        {
            NotificarErro(error);
            transaction.Rollback();
        }
    }
}
