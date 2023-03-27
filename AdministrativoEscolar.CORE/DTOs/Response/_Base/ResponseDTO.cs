using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministrativoEscolar.CORE.DTOs.Response.Base
{
    public class ResponseDTO
    {
        public bool Sucesso { get; set; }
        public string Mensagem { get; set; } = string.Empty;
        public string Detalhe { get; set; } = string.Empty;
        public IEnumerable<string>? Erros { get; set; }
    }
}
