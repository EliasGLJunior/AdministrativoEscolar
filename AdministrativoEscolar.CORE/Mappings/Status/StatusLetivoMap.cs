using AdministrativoEscolar.CORE.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdministrativoEscolar.CORE.Mappings.Status
{
    public class StatusLetivoMap : IEntityTypeConfiguration<StatusLetivo>
    {
        public void Configure(EntityTypeBuilder<StatusLetivo> builder)
        {
            builder.HasKey(x => x.IdStatusLetivo);
        }
    }
}
