using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdministrativoEscolar.CORE.Entities;

namespace AdministrativoEscolar.READ.Queries.AlunoQ
{
    public interface IAlunoQuery
    {
        Task<Aluno> GetAlunoById(int idAluno);
        Task<Aluno> GetAlunoByCPF(string nuCPF);
        Task<int> QuantidadeAlunos();
    }
}
