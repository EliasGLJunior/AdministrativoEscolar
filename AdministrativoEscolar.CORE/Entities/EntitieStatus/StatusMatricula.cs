using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministrativoEscolar.CORE.Entities
{
    public class StatusMatricula
    {
        public int IdStatusMatricula { get; set; }
        public string CdStatusMatricula { get; set; } = string.Empty;
        public string TxStatusMatricula { get; set; } = string.Empty;
        public virtual ICollection<StatusMatriculaHistorico>? HistoricoMatricula { get; set; }
    }
}
