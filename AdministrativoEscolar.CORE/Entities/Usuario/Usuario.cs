using AdministrativoEscolar.CORE.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministrativoEscolar.CORE.Entities
{
    public class Usuario : BaseEntitie
    {
        public int IdUsuario { get; set; }
        public int? IdEscola { get; set; }
        public int IdTipoUsuario { get; set; }
        public string TxEmail { get; set; } = string.Empty;
        public string TxSenha { get; set; } = string.Empty;
        public Escola? Escola { get; set; }
        public Aluno? Aluno { get; set; }
        public ResponsavelAluno? ResponsavelAluno { get; set; }
        public TipoUsuario? TipoUsuario { get; set; }
    }
}
