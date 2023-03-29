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

namespace AdministrativoEscolar.READ.Queries.EnderecoQ
{
    public class EnderecoAlunoQuery : IEnderecoAlunoQuery
    {
        private readonly IConfiguration _config;
        public EnderecoAlunoQuery(IConfiguration config) => _config = config;

        public IDbConnection Connection
        {
            get { return new SqlConnection(_config.GetConnectionString("Main")); }
        }

        string sql = @"SELECT EA.[IdEnderecoAluno] AS IdEnderecoAluno
					  FROM [dbo].[EnderecoAlunos] AS EA";

        public async Task<EnderecoAluno> GetEnderecoById(int idEndereco)
        {
            try
            {
                using (IDbConnection connection = Connection)
                {
                    sql += @$" WHERE EA.[IdEnderecoAluno] = {idEndereco} AND EA.[DtDelecao] IS NULL";

                    var result = await connection.QueryFirstOrDefaultAsync<EnderecoAluno>(sql, null);
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

        public async Task<EnderecoAluno> GetEnderecoByIdAluno(int idAluno)
        {
            try
            {
                using (IDbConnection connection = Connection)
                {
                    sql += @$" WHERE EA.[IdAluno] = {idAluno} AND EA.[FlEnderecoAtual] = 1 AND EA.[DtDelecao] IS NULL";

                    var result = await connection.QueryFirstOrDefaultAsync<EnderecoAluno>(sql, null);
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
