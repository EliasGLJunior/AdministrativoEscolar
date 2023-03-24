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
    public class EscolaMap : IEntityTypeConfiguration<Escola>
    {
        public void Configure(EntityTypeBuilder<Escola> builder)
        {
            builder.HasKey(x => x.IdEscola);

            builder.Property(x => x.NmEscola)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.CdEscola)
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(x => x.NuTelefone)
                .HasMaxLength(11)
                .IsRequired();

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
        }
    }
}
