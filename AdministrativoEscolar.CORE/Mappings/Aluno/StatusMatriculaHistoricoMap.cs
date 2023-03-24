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
    public class StatusMatriculaHistoricoMap : IEntityTypeConfiguration<StatusMatriculaHistorico>
    {
        public void Configure(EntityTypeBuilder<StatusMatriculaHistorico> builder)
        {
            builder.HasKey(x => new { x.IdMatricula, x.IdStatusMatricula });

            builder.HasOne(x => x.Matricula).WithMany(x => x.Historico).HasForeignKey(x => x.IdMatricula);
            builder.HasOne(x => x.StatusMatricula).WithMany(x => x.HistoricoMatricula).HasForeignKey(x => x.IdStatusMatricula);
        }
    }
}
