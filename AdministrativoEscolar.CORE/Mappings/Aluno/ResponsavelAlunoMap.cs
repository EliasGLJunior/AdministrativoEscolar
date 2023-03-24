using AdministrativoEscolar.CORE.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministrativoEscolar.CORE.Mappings
{
    public class ResponsavelAlunoMap : IEntityTypeConfiguration<ResponsavelAluno>
    {
        public void Configure(EntityTypeBuilder<ResponsavelAluno> builder)
        {
            builder.HasKey(x => x.IdResponsavelAluno );

            builder.Property(x => x.NmResponsavel)
                .HasMaxLength(20)
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

            builder.HasOne(x => x.Aluno).WithMany(x => x.Responsaveis).HasForeignKey(x => x.IdAluno);
            builder.HasOne(x => x.Usuario).WithOne(x => x.ResponsavelAluno).HasForeignKey<ResponsavelAluno>(x => x.IdUsuario).OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
