﻿using AdministrativoEscolar.CORE.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AdministrativoEscolar.CORE.Context
{
    public class AdmEscolarDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public AdmEscolarDbContext()
        {
        }

        public AdmEscolarDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public AdmEscolarDbContext(DbContextOptions<AdmEscolarDbContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

    #region DbSets de Alunos

    public DbSet<Aluno> Alunos { get; set; }
        public DbSet<AlunoStatusLetivoHistorico> AlunoStatusLetivoHistoricos { get; set; }
        public DbSet<EnderecoAluno> EnderecoAlunos { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }
        public DbSet<ResponsavelAluno> ResponsavelAlunos { get; set; }
        public DbSet<StatusLetivo> StatusLetivos { get; set; }
        public DbSet<StatusMatricula> StatusMatriculas { get; set; }
        public DbSet<StatusMatriculaHistorico> StatusMatriculaHistoricos { get; set; }

        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured) return;

            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("Main"));

            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aluno>().HasKey(i => i.IdAluno);
            modelBuilder.Entity<AlunoStatusLetivoHistorico>().HasKey(i => i.IdStatusLetivoHistorico);
            modelBuilder.Entity<EnderecoAluno>().HasKey(i => i.IdEnderecoAluno);
            modelBuilder.Entity<Matricula>().HasKey(i => i.IdMatricula);
            modelBuilder.Entity<ResponsavelAluno>().HasKey(i => i.IdResponsavelAluno);
            modelBuilder.Entity<StatusLetivo>().HasKey(i => i.IdStatusLetivo);
            modelBuilder.Entity<StatusMatricula>().HasKey(i => i.IdStatusMatricula);
            modelBuilder.Entity<StatusMatriculaHistorico>().HasKey(i => i.IdStatusMatriculaHistorico);

            SeedStatusLetivo(modelBuilder);
            SeedStatusMatricula(modelBuilder);
        }

        private static void SeedStatusLetivo(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StatusLetivo>().HasData(
                new StatusLetivo
                {
                    IdStatusLetivo = 1,
                    CdStatusLetivo = "primeiro_creche",
                    TxStatusLetivo = "1º Creche",
                    TxTipoEnsino = "creche"
                },
                new StatusLetivo
                {
                    IdStatusLetivo = 2,
                    CdStatusLetivo = "segundo_creche",
                    TxStatusLetivo = "2º Creche",
                    TxTipoEnsino = "creche"
                }, new StatusLetivo
                {
                    IdStatusLetivo = 3,
                    CdStatusLetivo = "terceiro_creche",
                    TxStatusLetivo = "3º Creche",
                    TxTipoEnsino = "creche"
                }, new StatusLetivo
                {
                    IdStatusLetivo = 4,
                    CdStatusLetivo = "primeiro_ensino_infantil",
                    TxStatusLetivo = "1º Ensino Infantil",
                    TxTipoEnsino = "ensino_infantil"
                },
                new StatusLetivo
                {
                    IdStatusLetivo = 5,
                    CdStatusLetivo = "segundo_ensino_infantil",
                    TxStatusLetivo = "2º Ensino Infantil",
                    TxTipoEnsino = "ensino_infantil"
                }, new StatusLetivo
                {
                    IdStatusLetivo = 6,
                    CdStatusLetivo = "primeiro_fundamental",
                    TxStatusLetivo = "1º Fundamental",
                    TxTipoEnsino = "ensino_fundamental_um"
                },
                new StatusLetivo
                {
                    IdStatusLetivo = 7,
                    CdStatusLetivo = "segundo_fundamental",
                    TxStatusLetivo = "2º Fundamental",
                    TxTipoEnsino = "ensino_fundamental_um"
                }, new StatusLetivo
                {
                    IdStatusLetivo = 8,
                    CdStatusLetivo = "terceiro_fundamental",
                    TxStatusLetivo = "3º Fundamental",
                    TxTipoEnsino = "ensino_fundamental_um"
                },
                new StatusLetivo
                {
                    IdStatusLetivo = 9,
                    CdStatusLetivo = "quarto_fundamental",
                    TxStatusLetivo = "4º Fundamental",
                    TxTipoEnsino = "ensino_fundamental_um"
                }, new StatusLetivo
                {
                    IdStatusLetivo = 10,
                    CdStatusLetivo = "quinto_fundamental",
                    TxStatusLetivo = "5º Fundamental",
                    TxTipoEnsino = "ensino_fundamental_um"
                },
                new StatusLetivo
                {
                    IdStatusLetivo = 11,
                    CdStatusLetivo = "sexto_fundamental",
                    TxStatusLetivo = "6º Fundamental",
                    TxTipoEnsino = "ensino_fundamental_dois"
                }, new StatusLetivo
                {
                    IdStatusLetivo = 12,
                    CdStatusLetivo = "setimo_fundamental",
                    TxStatusLetivo = "7º Fundamental",
                    TxTipoEnsino = "ensino_fundamental_dois"
                },
                new StatusLetivo
                {
                    IdStatusLetivo = 13,
                    CdStatusLetivo = "oitavo_fundamental",
                    TxStatusLetivo = "8º Fundamental",
                    TxTipoEnsino = "ensino_fundamental_dois"
                },
                new StatusLetivo
                {
                    IdStatusLetivo = 14,
                    CdStatusLetivo = "nono_fundamental",
                    TxStatusLetivo = "9º Fundamental",
                    TxTipoEnsino = "ensino_fundamental_dois"
                },
                new StatusLetivo
                {
                    IdStatusLetivo = 15,
                    CdStatusLetivo = "primeiro_ensino_medio",
                    TxStatusLetivo = "1º Ensino Médio",
                    TxTipoEnsino = "ensino_medio"
                },
                new StatusLetivo
                {
                    IdStatusLetivo = 16,
                    CdStatusLetivo = "segundo_ensino_medio",
                    TxStatusLetivo = "2º Ensino Médio",
                    TxTipoEnsino = "ensino_medio"
                },
                new StatusLetivo
                {
                    IdStatusLetivo = 17,
                    CdStatusLetivo = "terceiro_ensino_medio",
                    TxStatusLetivo = "3º Ensino Médio",
                    TxTipoEnsino = "ensino_medio"
                },
                new StatusLetivo
                {
                    IdStatusLetivo = 18,
                    CdStatusLetivo = "quarto_ensino_medio",
                    TxStatusLetivo = "4º Ensino Médio",
                    TxTipoEnsino = "ensino_medio"
                },
                new StatusLetivo
                {
                    IdStatusLetivo = 19,
                    CdStatusLetivo = "primeiro_ensino_medio_tecnico",
                    TxStatusLetivo = "1º Ensino Médio Técnico",
                    TxTipoEnsino = "ensino_medio_tecnico"
                },
                new StatusLetivo
                {
                    IdStatusLetivo = 20,
                    CdStatusLetivo = "segundo_ensino_medio_tecnico",
                    TxStatusLetivo = "2º Ensino Médio Técnico",
                    TxTipoEnsino = "ensino_medio_tecnico"
                },
                new StatusLetivo
                {
                    IdStatusLetivo = 21,
                    CdStatusLetivo = "terceiro_ensino_medio_tecnico",
                    TxStatusLetivo = "3º Ensino Médio Técnico",
                    TxTipoEnsino = "ensino_medio_tecnico"
                },
                new StatusLetivo
                {
                    IdStatusLetivo = 22,
                    CdStatusLetivo = "quarto_ensino_medio_tecnico",
                    TxStatusLetivo = "4º Ensino Médio Técnico",
                    TxTipoEnsino = "ensino_medio_tecnico"
                },
                new StatusLetivo
                {
                    IdStatusLetivo = 23,
                    CdStatusLetivo = "primeiro_semestre_ensino_tecnico",
                    TxStatusLetivo = "1º Semestre Ensino Técnico",
                    TxTipoEnsino = "ensino_tecnico"
                },
                new StatusLetivo
                {
                    IdStatusLetivo = 24,
                    CdStatusLetivo = "segundo_semestre_ensino_tecnico",
                    TxStatusLetivo = "2º Semestre Ensino Técnico",
                    TxTipoEnsino = "ensino_tecnico"
                },
                new StatusLetivo
                {
                    IdStatusLetivo = 25,
                    CdStatusLetivo = "terceiro_semestre_ensino_tecnico",
                    TxStatusLetivo = "3º Semestre Ensino Técnico",
                    TxTipoEnsino = "ensino_tecnico"
                },
                new StatusLetivo
                {
                    IdStatusLetivo = 26,
                    CdStatusLetivo = "quarto_semestre_ensino_tecnico",
                    TxStatusLetivo = "4º Semestre Ensino Técnico",
                    TxTipoEnsino = "ensino_tecnico"
                },
                new StatusLetivo
                {
                    IdStatusLetivo = 27,
                    CdStatusLetivo = "primeiro_semestre_superior",
                    TxStatusLetivo = "1º Semestre Superior",
                    TxTipoEnsino = "ensino_superior"
                },
                new StatusLetivo
                {
                    IdStatusLetivo = 28,
                    CdStatusLetivo = "segundo_semestre_superior",
                    TxStatusLetivo = "2º Semestre Superior",
                    TxTipoEnsino = "ensino_superior"
                },
                new StatusLetivo
                {
                    IdStatusLetivo = 29,
                    CdStatusLetivo = "terceiro_semestre_superior",
                    TxStatusLetivo = "3º Semestre Superior",
                    TxTipoEnsino = "ensino_superior"
                },
                new StatusLetivo
                {
                    IdStatusLetivo = 30,
                    CdStatusLetivo = "quarto_semestre_superior",
                    TxStatusLetivo = "4º Semestre Superior",
                    TxTipoEnsino = "ensino_superior"
                },
                new StatusLetivo
                {
                    IdStatusLetivo = 31,
                    CdStatusLetivo = "quinto_semestre_superior",
                    TxStatusLetivo = "5º Semestre Superior",
                    TxTipoEnsino = "ensino_superior"
                },
                new StatusLetivo
                {
                    IdStatusLetivo = 32,
                    CdStatusLetivo = "sexto_semestre_superior",
                    TxStatusLetivo = "6º Semestre Superior",
                    TxTipoEnsino = "ensino_superior"
                },
                new StatusLetivo
                {
                    IdStatusLetivo = 33,
                    CdStatusLetivo = "setimo_semestre_superior",
                    TxStatusLetivo = "7º Semestre Superior",
                    TxTipoEnsino = "ensino_superior"
                },
                new StatusLetivo
                {
                    IdStatusLetivo = 34,
                    CdStatusLetivo = "oitavo_semestre_superior",
                    TxStatusLetivo = "8º Semestre Superior",
                    TxTipoEnsino = "ensino_superior"
                },
                new StatusLetivo
                {
                    IdStatusLetivo = 35,
                    CdStatusLetivo = "nono_semestre_superior",
                    TxStatusLetivo = "9º Semestre Superior",
                    TxTipoEnsino = "ensino_superior"
                },
                new StatusLetivo
                {
                    IdStatusLetivo = 36,
                    CdStatusLetivo = "decimo_semestre_superior",
                    TxStatusLetivo = "10º Semestre Superior",
                    TxTipoEnsino = "ensino_superior"
                },
                new StatusLetivo
                {
                    IdStatusLetivo = 37,
                    CdStatusLetivo = "decimo_primeiro_semestre_superior",
                    TxStatusLetivo = "11º Semestre Superior",
                    TxTipoEnsino = "ensino_superior"
                },
                new StatusLetivo
                {
                    IdStatusLetivo = 38,
                    CdStatusLetivo = "decimo_segundo_semestre_superior",
                    TxStatusLetivo = "12º Semestre Superior",
                    TxTipoEnsino = "ensino_superior"
                }
            );
        }

        private static void SeedStatusMatricula(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StatusMatricula>().HasData(
                new StatusMatricula
                {
                    IdStatusMatricula = 1, //Matriculado: indica que o aluno está atualmente matriculado em um curso ou disciplina.
                    CdStatusMatricula = "matriculado",
                    TxStatusMatricula = "Matriculado"
                },
                new StatusMatricula
                {
                    IdStatusMatricula = 2, //Pendente: indica que a matrícula do aluno ainda não foi processada ou está em espera de uma ação específica, como pagamento de taxas.
                    CdStatusMatricula = "pendente",
                    TxStatusMatricula = "Pendente"
                },
                new StatusMatricula
                {
                    IdStatusMatricula = 3, //Trancado: indica que o aluno suspendeu temporariamente a matrícula em um curso ou disciplina, mas planeja retomá-la em algum momento no futuro.
                    CdStatusMatricula = "trancado",
                    TxStatusMatricula = "Trancado"
                },
                new StatusMatricula
                {
                    IdStatusMatricula = 4, //Cancelado: a matrícula do aluno foi cancelada por algum motivo, como inadimplência, mau desempenho acadêmico ou violação de políticas da instituição.
                    CdStatusMatricula = "cancelado",
                    TxStatusMatricula = "Cancelado"
                },
                new StatusMatricula
                {
                    IdStatusMatricula = 5, //Desistência: indica que o aluno desistiu do curso ou disciplina, antes de concluir todas as exigências.
                    CdStatusMatricula = "desistencia",
                    TxStatusMatricula = "Desistência"
                },
                new StatusMatricula
                {
                    IdStatusMatricula = 6, //Transferido: indica que o aluno transferiu-se para outro curso ou instituição.
                    CdStatusMatricula = "transferido",
                    TxStatusMatricula = "Transferido"
                },
                new StatusMatricula
                {
                    IdStatusMatricula = 7, //Rejeitado: a matrícula do aluno foi negada por algum motivo, como falta de requisitos de admissão ou número de vagas preenchidas.
                    CdStatusMatricula = "rejeitado",
                    TxStatusMatricula = "Rejeitado"
                },
                new StatusMatricula
                {
                    IdStatusMatricula = 8, //Suspenso: o aluno foi suspenso temporariamente devido a violações das políticas da instituição ou do código de conduta.
                    CdStatusMatricula = "suspenso",
                    TxStatusMatricula = "Suspenso"
                },
                new StatusMatricula
                {
                    IdStatusMatricula = 9, //Expulso: o aluno foi expulso permanentemente da instituição devido a violações graves das políticas da instituição ou do código de conduta.
                    CdStatusMatricula = "expulso",
                    TxStatusMatricula = "Expulso"
                },
                new StatusMatricula
                {
                    IdStatusMatricula = 10, //Graduado: o aluno se formou na instituição.
                    CdStatusMatricula = "graduado",
                    TxStatusMatricula = "Graduado"
                }
            );
        }
    }
}