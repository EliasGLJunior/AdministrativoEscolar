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
    public class StatusMatriculaMap : IEntityTypeConfiguration<StatusMatricula>
    {
        public void Configure(EntityTypeBuilder<StatusMatricula> builder)
        {
            builder.HasKey(x => x.IdStatusMatricula);
        }
    }
}
