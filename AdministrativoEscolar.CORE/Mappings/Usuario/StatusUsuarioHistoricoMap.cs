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
    public class StatusUsuarioHistoricoMap : IEntityTypeConfiguration<StatusUsuarioHistorico>
    {
        public void Configure(EntityTypeBuilder<StatusUsuarioHistorico> builder)
        {
            builder.HasKey(x => new { x.IdUsuario, x.IdStatusUsuario });

            builder.HasOne(x => x.Usuario).WithMany(x => x.Historico).HasForeignKey(x => x.IdUsuario);
            builder.HasOne(x => x.StatusUsuario).WithMany(x => x.HistoricoUsuario).HasForeignKey(x => x.IdStatusUsuario);
        }
    }
}
