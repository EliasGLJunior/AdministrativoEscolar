using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministrativoEscolar.CORE.Entities.Base
{
    public class BaseEntitie
    {
        public DateTime DtCriacao { get; set; } = DateTime.Now;
        public DateTime DtAtualizacao { get; set; } = DateTime.Now;
        public DateTime? DtDelecao { get; set; }
    }
}
