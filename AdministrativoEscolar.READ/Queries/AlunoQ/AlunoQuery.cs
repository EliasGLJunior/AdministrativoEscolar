using AdministrativoEscolar.CORE.Entities;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace AdministrativoEscolar.READ.Queries.AlunoQ
{
    public class AlunoQuery : IAlunoQuery
    {
        private readonly IConfiguration _config;
        public AlunoQuery(IConfiguration config) => _config = config;

        public IDbConnection Connection
        {
            get { return new SqlConnection(_config.GetConnectionString("Main")); }
        }

        string sql = @"SELECT A.[IdAluno] AS IdAluno
					  FROM [dbo].[Alunos] AS A";
        
        public async Task<Aluno> GetAlunoById(int idAluno)
        {
            try
            {
                using (IDbConnection connection = Connection)
                {
                    sql += @$" WHERE A.[IdAluno] = {idAluno}";
                    var result = await connection.QueryFirstOrDefaultAsync<Aluno>(sql, null);
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

        public async Task<Aluno> GetAlunoByCPF(string nuCPF)
        {
            try
            {
                using (IDbConnection connection = Connection)
                {
                    sql += @$" WHERE A.[NuCPF] = '{nuCPF}'";
                    var result = await connection.QueryFirstOrDefaultAsync<Aluno>(sql, null);
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

        public async Task<int> QuantidadeAlunos()
        {
            try
            {
                using (IDbConnection connection = Connection)
                {
                    sql = @"SELECT COUNT(*) FROM [dbo].[Alunos] AS A WHERE YEAR(A.[DtCriacao]) = YEAR(GETDATE())";
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
