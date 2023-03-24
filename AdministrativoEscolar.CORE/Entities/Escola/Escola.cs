using AdministrativoEscolar.CORE.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministrativoEscolar.CORE.Entities
{
    public class Escola : BaseEntitie
    {
        public int IdEscola { get; set; }
        public string CdEscola { get; set; } = string.Empty;
        public string NmEscola { get; set; } = string.Empty;
        public string NuTelefone { get; set; } = string.Empty;
        public string TxEndereco { get; set; } = string.Empty;
        public string NuEndereco { get; set; } = string.Empty;
        public string NuCepEndereco { get; set; } = string.Empty;
        public string TxBairro { get; set; } = string.Empty;
        public string TxCidade { get; set; } = string.Empty;
        public string TxEstado { get; set; } = string.Empty;
        public virtual ICollection<Aluno>? Alunos { get; set; }
        public virtual ICollection<Usuario>? Usuarios { get; set; }
    }
}
