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

namespace AdministrativoEscolar.READ.Queries.StatusUsuarioQ
{
    public class StatusUsuarioQuery : IStatusUsuarioQuery
    {
        private readonly IConfiguration _config;
        public StatusUsuarioQuery(IConfiguration config) => _config = config;

        public IDbConnection Connection
        {
            get { return new SqlConnection(_config.GetConnectionString("Main")); }
        }

        string sql = @"SELECT SU.[IdStatusUsuario] AS IdStatusUsuario
					  FROM [dbo].[StatusUsuarios] AS SU";
        public async Task<int> GetIdByCdStatusUsuario(string cdStatusUsuario)
        {
            try
            {
                using (IDbConnection connection = Connection)
                {
                    sql = @$"  WHERE SU.[CdStatusUsuario] = '{cdStatusUsuario}'";

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
