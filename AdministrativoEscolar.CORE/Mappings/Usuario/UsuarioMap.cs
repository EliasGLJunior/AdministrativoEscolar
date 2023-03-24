using AdministrativoEscolar.CORE.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdministrativoEscolar.CORE.Mappings
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(x => x.IdUsuario);

            builder.Property(x => x.TxEmail)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.TxSenha)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.IdEscola)
                .IsRequired(false);

            builder.HasOne(x => x.Escola).WithMany(x => x.Usuarios).HasForeignKey(x => x.IdEscola);
            builder.HasOne(x => x.TipoUsuario).WithMany(x => x.Usuarios).HasForeignKey(x => x.IdTipoUsuario);
        }
    }
}
