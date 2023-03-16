using AdministrativoEscolar.CORE.Entities;
using Microsoft.EntityFrameworkCore;

namespace AdministrativoEscolar.CORE.Context
{
    public class AdmEscolarDbContext : DbContext
    {
        public AdmEscolarDbContext(DbContextOptions<AdmEscolarDbContext> options) : base(options) { }

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
    }
}