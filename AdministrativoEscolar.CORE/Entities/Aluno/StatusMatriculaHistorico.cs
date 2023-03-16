using AdministrativoEscolar.CORE.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministrativoEscolar.CORE.Entities
{
    public class StatusMatriculaHistorico : BaseEntitie
    {
        public int IdMatricula { get; set; }
        public int IdStatusMatricula { get; set; }
        public bool FlStatusAtual { get; set; }
        public virtual Matricula? Matricula { get; set; }
        public virtual StatusMatricula? StatusMatricula { get; set; }
    }
}
