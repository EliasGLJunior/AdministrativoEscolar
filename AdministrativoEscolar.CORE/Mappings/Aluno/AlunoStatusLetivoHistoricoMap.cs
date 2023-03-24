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
    public class AlunoStatusLetivoHistoricoMap : IEntityTypeConfiguration<AlunoStatusLetivoHistorico>
    {
        public void Configure(EntityTypeBuilder<AlunoStatusLetivoHistorico> builder)
        {
            builder.HasKey(x => new { x.IdAluno, x.IdStatusLetivo});

            builder.HasOne(x => x.Aluno).WithMany(x => x.StatusLetivoHistorico).HasForeignKey(x => x.IdAluno);
            builder.HasOne(x => x.StatusLetivo).WithMany(x => x.Alunos).HasForeignKey(x => x.IdStatusLetivo);
        }
    }
}
