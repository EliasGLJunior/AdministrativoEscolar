using AdministrativoEscolar.CORE.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdministrativoEscolar.CORE.Mappings
{
    public class MatriculaMap : IEntityTypeConfiguration<Matricula>
    {
        public void Configure(EntityTypeBuilder<Matricula> builder)
        {
            builder.HasKey(x => x.IdMatricula);

            builder.Property(x => x.NuMatricula)
                .HasMaxLength(10);
        }
    }
}
