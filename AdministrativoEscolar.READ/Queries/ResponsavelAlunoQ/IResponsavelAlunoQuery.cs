using AdministrativoEscolar.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministrativoEscolar.READ.Queries.ResponsavelAlunoQ
{
    public interface IResponsavelAlunoQuery
    {
        Task<ResponsavelAluno> GetResponsavelById(int idResponsavel);
        Task<ResponsavelAluno> GetResponsavelByIdAluno(int idAluno);
    }
}
