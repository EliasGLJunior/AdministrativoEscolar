using AdministrativoEscolar.CORE.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministrativoEscolar.CORE.Mappings
{
    public class EnderecoAlunoMap : IEntityTypeConfiguration<EnderecoAluno>
    {
        public void Configure(EntityTypeBuilder<EnderecoAluno> builder)
        {
            builder.HasKey(x => x.IdEnderecoAluno);

            builder.Property(x => x.TxBairro)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(x => x.TxCidade)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(x => x.TxEndereco)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.TxEstado)
                .HasMaxLength(15)
                .IsRequired();

            builder.Property(x => x.NuCepEndereco)
                .HasMaxLength(8)
                .IsRequired();

            builder.Property(x => x.NuEndereco)
                .HasMaxLength(6)
                .IsRequired();

            builder.HasOne(x => x.Aluno).WithMany(x => x.Enderecos).HasForeignKey(x => x.IdAluno);
        }
    }
}
