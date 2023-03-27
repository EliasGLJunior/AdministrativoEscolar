using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministrativoEscolar.CORE.Entities
{
    public class StatusLetivo
    {
        public int IdStatusLetivo { get; set; }
        public string CdStatusLetivo { get; set; } = string.Empty;
        public string TxStatusLetivo { get; set; } = string.Empty;
        public string TxTipoEnsino { get; set; } = string.Empty;
        public virtual ICollection<AlunoStatusLetivoHistorico>? Alunos { get; set; }
    }
}
