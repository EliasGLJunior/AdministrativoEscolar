using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministrativoEscolar.CORE.DTOs.Request.Aluno
{
    public class CreateAlunoRequestDTO
    {
        public AlunoDTO? Aluno { get; set; }
        public EnderecoDTO? Endereco { get; set; }
        public List<ResponsavelDTO>? Responsaveis { get; set; }

    }
    public class AlunoDTO
    {
        public int IdStatusLetivo { get; set; }
        public string NmAluno { get; set; } = string.Empty;
        public string SbnmAluno { get; set; } = string.Empty;
        public string NuTelefone { get; set; } = string.Empty;
        public string NuRG { get; set; } = string.Empty;
        public string NuCPF { get; set; } = string.Empty;
        public string TxNacionalidade { get; set; } = string.Empty;
        public string TxEmail { get; set; } = string.Empty;
        public DateTime DtNascimento { get; set; }
    }
    public class EnderecoDTO
    {
        public string TxEndereco { get; set; } = string.Empty;
        public string NuEndereco { get; set; } = string.Empty;
        public string NuCepEndereco { get; set; } = string.Empty;
        public string TxBairro { get; set; } = string.Empty;
        public string TxCidade { get; set; } = string.Empty;
        public string TxEstado { get; set; } = string.Empty;
    }

    public class ResponsavelDTO
    {
        public string NmResponsavel { get; set; } = string.Empty;
        public string NuTelefone { get; set; } = string.Empty;
        public string NuRG { get; set; } = string.Empty;
        public string NuCPF { get; set; } = string.Empty;
        public string TxEmail { get; set; } = string.Empty;
        public DateTime DtNascimento { get; set; }
        public bool FlResponsavelPrincipal { get; set; }
    }
}
