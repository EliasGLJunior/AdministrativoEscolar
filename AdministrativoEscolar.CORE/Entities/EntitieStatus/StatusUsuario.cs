using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministrativoEscolar.CORE.Entities
{
    public class StatusUsuario
    {
        public int IdStatusUsuario { get; set; }
        public string CdStatusUsuario { get; set; } = string.Empty;
        public string TxStatusUsuario { get; set; } = string.Empty;
        public virtual ICollection<StatusUsuarioHistorico>? HistoricoUsuario { get; set; }
    }
}
