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

namespace AdministrativoEscolar.READ.Queries.MatriculaQ
{
    public class MatriculaQuery : IMatriculaQuery
    {
        private readonly IConfiguration _config;
        public MatriculaQuery(IConfiguration config) => _config = config;

        public IDbConnection Connection
        {
            get { return new SqlConnection(_config.GetConnectionString("Main")); }
        }

        string sql = @"SELECT M.[NuMatricula] AS NuMatricula
					  FROM [dbo].[Matriculas] AS M";

        public async Task<string> GetNuMatriculaByIdAluno(int idAluno)
        {
            try
            {
                using (IDbConnection connection = Connection)
                {
                    sql += @$"  INNER JOIN [dbo].[Alunos] AS A ON M.[IdMatricula] = A.[IdMatricula]
                                WHERE A.[IdAluno] = {idAluno} AND M.[DtDelecao] IS NULL";

                    var result = await connection.QueryFirstOrDefaultAsync<string>(sql, null);
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
