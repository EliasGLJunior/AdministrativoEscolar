using AdministrativoEscolar.CORE.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdministrativoEscolar.CORE.Mappings
{
    public class AlunoMap : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            builder.HasKey(x => x.IdAluno);

            builder.Property(x => x.NmAluno)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(x => x.SbnmAluno)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.NuCPF)
                .HasMaxLength(11)
                .IsRequired();

            builder.Property(x => x.NuRG)
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(x => x.NuTelefone)
                .HasMaxLength(11)
                .IsRequired();

            builder.Property(x => x.TxNacionalidade)
                .HasMaxLength(25)
                .IsRequired();

            builder.HasOne(x => x.Escola).WithMany(x => x.Alunos).HasForeignKey(x => x.IdEscola);
            builder.HasOne(x => x.Matricula).WithOne(x => x.Aluno).HasForeignKey<Aluno>(x => x.IdMatricula).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasOne(x => x.Usuario).WithOne(x => x.Aluno).HasForeignKey<Aluno>(x => x.IdUsuario).OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
