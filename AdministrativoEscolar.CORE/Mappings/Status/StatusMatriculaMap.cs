using AdministrativoEscolar.CORE.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdministrativoEscolar.CORE.Mappings.Status
{
    public class StatusMatriculaMap : IEntityTypeConfiguration<StatusMatricula>
    {
        public void Configure(EntityTypeBuilder<StatusMatricula> builder)
        {
            builder.HasKey(x => x.IdStatusMatricula);
        }
    }
}
