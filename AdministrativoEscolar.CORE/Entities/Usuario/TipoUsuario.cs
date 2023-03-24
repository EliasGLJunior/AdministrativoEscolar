using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministrativoEscolar.CORE.Entities
{
    public class TipoUsuario
    {
        public int IdTipoUsuario { get; set; }
        public string CdTipoUsuario { get; set; } = string.Empty;
        public string TxTipoUsuario { get; set; } = string.Empty;
        public ICollection<Usuario>? Usuarios { get; set; }
    }
}
