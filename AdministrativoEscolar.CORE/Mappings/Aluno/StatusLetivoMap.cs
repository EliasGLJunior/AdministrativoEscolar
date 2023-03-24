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
    public class StatusLetivoMap : IEntityTypeConfiguration<StatusLetivo>
    {
        public void Configure(EntityTypeBuilder<StatusLetivo> builder)
        {
            builder.HasKey(x => x.IdStatusLetivo);
        }
    }
}
