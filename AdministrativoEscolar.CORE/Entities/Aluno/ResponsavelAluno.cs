using AdministrativoEscolar.CORE.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministrativoEscolar.CORE.Entities
{
    public class ResponsavelAluno : BaseEntitie
    {
        public int IdResponsavelAluno { get; set; }
        public int IdAluno { get; set; }
        public string NmResponsavel { get; set; } = string.Empty;
        public string NuTelefone { get; set; } = string.Empty;
        public string NuRG { get; set; } = string.Empty;
        public string NuCPF { get; set; } = string.Empty;
        public DateTime DtNascimento { get; set; }
        public bool FlResponsavelPrincipal { get; set; }
        public virtual Aluno? Aluno { get; set; }
    }
}
