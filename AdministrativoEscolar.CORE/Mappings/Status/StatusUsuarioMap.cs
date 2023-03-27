using AdministrativoEscolar.CORE.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministrativoEscolar.CORE.Mappings.Status
{
    public class StatusUsuarioMap : IEntityTypeConfiguration<StatusUsuario>
    {
        public void Configure(EntityTypeBuilder<StatusUsuario> builder)
        {
            builder.HasKey(x => x.IdStatusUsuario);
        }
    }
}
