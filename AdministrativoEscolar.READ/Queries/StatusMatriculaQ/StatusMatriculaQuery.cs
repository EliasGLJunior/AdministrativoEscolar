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

namespace AdministrativoEscolar.READ.Queries.StatusMatriculaQ
{
    public class StatusMatriculaQuery : IStatusMatriculaQuery
    {
        private readonly IConfiguration _config;
        public StatusMatriculaQuery(IConfiguration config) => _config = config;

        public IDbConnection Connection
        {
            get { return new SqlConnection(_config.GetConnectionString("Main")); }
        }

        string sql = @"SELECT SM.[IdStatusMatricula] AS IdStatusMatricula
					  FROM [dbo].[StatusMatriculas] AS SM";

        public async Task<int> GetIdByCdStatusMatricula(string cdStatusMatricula)
        {
            try
            {
                using (IDbConnection connection = Connection)
                {
                    sql = @$"  WHERE SU.[CdStatusMatricula] = '{cdStatusMatricula}'";

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
