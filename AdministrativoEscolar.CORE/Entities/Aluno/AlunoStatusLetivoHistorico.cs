using AdministrativoEscolar.CORE.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministrativoEscolar.CORE.Entities
{
    public class AlunoStatusLetivoHistorico : BaseEntitie
    {
        public int IdAluno { get; set; }
        public int IdStatusLetivo { get; set; }
        public bool FlStatusAtual { get; set; }
        public virtual Aluno? Aluno { get; set; }
        public virtual StatusLetivo? StatusLetivo { get; set; }
    }
}
