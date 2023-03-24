using AdministrativoEscolar.CORE.Entities;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministrativoEscolar.READ.Queries.TipoUsuarioQ
{
    public class TipoUsuarioQuery : ITipoUsuarioQuery
    {
        private readonly IConfiguration _config;
        public TipoUsuarioQuery(IConfiguration config) => _config = config;

        public IDbConnection Connection
        {
            get { return new SqlConnection(_config.GetConnectionString("Main")); }
        }

        string sql = @"SELECT TU.[IdTipoUsuario] AS IdTipoUsuario
					  FROM [dbo].[TipoUsuarios] AS TU";

        public async Task<int> GetIdByCdTipoUsuario(string cdTipoUsuario)
        {
            try
            {
                using (IDbConnection connection = Connection)
                {
                    sql = @$" SELECT TU.[IdTipoUsuario] AS IdTipoUsuario
					              FROM [dbo].[TipoUsuarios] AS TU
                                    WHERE TU.[CdTipoUsuario] = '{cdTipoUsuario}'";

                    var result = await connection.QueryFirstOrDefaultAsync<int>(sql, null);
                    connection.Close();
                    connection.Dispose();

                    return result;
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
