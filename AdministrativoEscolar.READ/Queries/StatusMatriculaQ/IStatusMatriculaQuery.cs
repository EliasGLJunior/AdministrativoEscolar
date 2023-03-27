using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministrativoEscolar.READ.Queries.StatusMatriculaQ
{
    public interface IStatusMatriculaQuery
    {
        Task<int> GetIdByCdStatusMatricula(string cdStatusMatricula);
    }
}
