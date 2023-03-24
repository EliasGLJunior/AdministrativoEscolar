using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministrativoEscolar.CORE.DTOs.Request.Aluno
{
    public class UpdateAlunoRequestDTO
    {
        public int IdAluno { get; set; }
        public string NmAluno { get; set; } = string.Empty;
        public string SbnmAluno { get; set; } = string.Empty;
        public string NuTelefone { get; set; } = string.Empty;
        public string NuRG { get; set; } = string.Empty;
        public string NuCPF { get; set; } = string.Empty;
        public string TxNacionalidade { get; set; } = string.Empty;
        public DateTime DtNascimento { get; set; }
    }
}
