namespace AdministrativoEscolar.CORE.DTOs.Request.EnderecoAluno
{
    public class UpdateEnderecoAlunoRequestDTO
    {
        public int IdEndereco { get; set; }
        public string TxEndereco { get; set; } = string.Empty;
        public string NuEndereco { get; set; } = string.Empty;
        public string NuCepEndereco { get; set; } = string.Empty;
        public string TxBairro { get; set; } = string.Empty;
        public string TxCidade { get; set; } = string.Empty;
        public string TxEstado { get; set; } = string.Empty;
        public bool FlEnderecoAtual { get; set; }
    }
}
