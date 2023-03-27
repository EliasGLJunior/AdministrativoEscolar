using AdministrativoEscolar.CORE.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministrativoEscolar.CORE.Entities
{
    public class Matricula : BaseEntitie
    {
        public int IdMatricula { get; set; }
        public string NuMatricula { get; set; } = string.Empty;
        public virtual ICollection<StatusMatriculaHistorico>? Historico { get; set; }
        public virtual Aluno? Aluno { get; set; }
    }
}
