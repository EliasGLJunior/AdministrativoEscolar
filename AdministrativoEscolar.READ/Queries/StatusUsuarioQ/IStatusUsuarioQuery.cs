using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministrativoEscolar.READ.Queries.StatusUsuarioQ
{
    public interface IStatusUsuarioQuery
    {
        Task<int> GetIdByCdStatusUsuario(string cdStatusUsuario);
    }
}
