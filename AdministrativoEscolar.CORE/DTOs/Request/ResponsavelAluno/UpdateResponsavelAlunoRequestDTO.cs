using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministrativoEscolar.CORE.DTOs.Request.ResponsavelAluno
{
    public class UpdateResponsavelAlunoRequestDTO
    {
        public int IdResponsavel { get; set; }
        public string NmResponsavel { get; set; } = string.Empty;
        public string NuTelefone { get; set; } = string.Empty;
        public string NuRG { get; set; } = string.Empty;
        public string NuCPF { get; set; } = string.Empty;
        public DateTime DtNascimento { get; set; }
        public bool FlResponsavelPrincipal { get; set; }
    }
}
