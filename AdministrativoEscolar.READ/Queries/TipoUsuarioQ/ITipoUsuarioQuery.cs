using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministrativoEscolar.READ.Queries.TipoUsuarioQ
{
    public interface ITipoUsuarioQuery
    {
        Task<int> GetIdByCdTipoUsuario(string cdTipoUsuario);
    }
}
