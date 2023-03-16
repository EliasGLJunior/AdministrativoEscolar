using AdministrativoEscolar.CORE.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministrativoEscolar.CORE.Entities
{
    public class EnderecoAluno : BaseEntitie
    {
        public int IdEnderecoAluno { get; set; }
        public int IdAluno { get; set; }
        public string TxEndereco { get; set; } = string.Empty;
        public string NuEndereco { get; set; } = string.Empty;
        public string NuCepEndereco { get; set; } = string.Empty;
        public string TxBairro { get; set; } = string.Empty;
        public string TxCidade { get; set; } = string.Empty;
        public string TxEstado { get; set; } = string.Empty;
        public bool FlEnderecoAtual { get; set; }
        public virtual Aluno? Aluno { get; set; }
    }
}
