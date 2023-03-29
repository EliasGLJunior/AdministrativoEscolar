using AdministrativoEscolar.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministrativoEscolar.READ.Queries.EnderecoQ
{
    public interface IEnderecoAlunoQuery
    {
        Task<EnderecoAluno> GetEnderecoById(int idEndereco);
        Task<EnderecoAluno> GetEnderecoByIdAluno(int idAluno);
    }
}
