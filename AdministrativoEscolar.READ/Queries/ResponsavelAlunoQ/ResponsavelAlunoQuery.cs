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

namespace AdministrativoEscolar.READ.Queries.ResponsavelAlunoQ
{
    public class ResponsavelAlunoQuery : IResponsavelAlunoQuery
    {
        private readonly IConfiguration _config;
        public ResponsavelAlunoQuery(IConfiguration config) => _config = config;

        public IDbConnection Connection
        {
            get { return new SqlConnection(_config.GetConnectionString("Main")); }
        }

        string sql = @"SELECT RA.[IdResponsavelAluno] AS IdResponsavelAluno
					  FROM [dbo].[ResponsavelAlunos] AS RA";

        public async Task<ResponsavelAluno> GetResponsavelById(int idResponsavel)
        {
            try
            {
                using (IDbConnection connection = Connection)
                {
                    sql += @$" WHERE RA.[IdResponsavelAluno] = {idResponsavel} AND RA.[DtDelecao] IS NULL";

                    var result = await connection.QueryFirstOrDefaultAsync<ResponsavelAluno>(sql, null);
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

        public async Task<ResponsavelAluno> GetResponsavelByIdAluno(int idAluno)
        {
            try
            {
                using (IDbConnection connection = Connection)
                {
                    sql += @$" WHERE RA.[IdAluno] = {idAluno} AND RA.[FlResponsavelPrincipal] = 1 AND RA.[DtDelecao] IS NULL";

                    var result = await connection.QueryFirstOrDefaultAsync<ResponsavelAluno>(sql, null);
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
