﻿using AdministrativoEscolar.CORE.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministrativoEscolar.CORE.Entities
{
    public class Aluno : BaseEntitie
    {
        public int IdAluno { get; set; }
        public int IdMatricula { get; set; }
        public string NmAluno { get; set; } = string.Empty;
        public string SbnmAluno { get; set; } = string.Empty;
        public string NuTelefone { get; set; } = string.Empty;
        public string NuRG { get; set; } = string.Empty;
        public string NuCPF { get; set; } = string.Empty;
        public string TxNacionalidade { get; set; } = string.Empty;
        public DateTime DtNascimento { get; set; }
        public virtual Matricula? Matricula { get; set; }
        public virtual ICollection<EnderecoAluno>? Enderecos { get; set; }
        public virtual ICollection<ResponsavelAluno>? Responsaveis { get; set; }
        public virtual ICollection<AlunoStatusLetivoHistorico>? StatusLetivoHistorico { get; set; }
    } 
}
