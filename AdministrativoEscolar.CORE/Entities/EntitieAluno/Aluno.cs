using AdministrativoEscolar.CORE.Entities.Base;

namespace AdministrativoEscolar.CORE.Entities
{
    public class Aluno : BaseEntitie
    {
        public int IdAluno { get; set; }
        public int IdEscola { get; set; }
        public int IdMatricula { get; set; }
        public int IdUsuario { get; set; }
        public string NmAluno { get; set; } = string.Empty;
        public string SbnmAluno { get; set; } = string.Empty;
        public string NuTelefone { get; set; } = string.Empty;
        public string NuRG { get; set; } = string.Empty;
        public string NuCPF { get; set; } = string.Empty;
        public string TxNacionalidade { get; set; } = string.Empty;
        public DateTime DtNascimento { get; set; }
        public virtual Matricula? Matricula { get; set; }
        public virtual Escola? Escola { get; set; }
        public virtual Usuario? Usuario { get; set; }
        public virtual ICollection<EnderecoAluno>? Enderecos { get; set; }
        public virtual ICollection<ResponsavelAluno>? Responsaveis { get; set; }
        public virtual ICollection<AlunoStatusLetivoHistorico>? StatusLetivoHistorico { get; set; }
    } 
}
