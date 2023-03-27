using AdministrativoEscolar.CORE.DTOs.Request;
using AdministrativoEscolar.CORE.DTOs.Response.Usuario;
using AdministrativoEscolar.CORE.Entities;
using AdministrativoEscolar.CORE.Notification;
using AdministrativoEscolar.CORE.Utils;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministrativoEscolar.READ.Queries.UsuarioQ
{
    public class UsuarioQuery : Notificar, IUsuarioQuery
    {
        private readonly IConfiguration _config;
        public UsuarioQuery(IConfiguration config, INotificador notificador) : base(notificador) => _config = config;

        public IDbConnection Connection
        {
            get { return new SqlConnection(_config.GetConnectionString("Main")); }
        }

        string sql = @"SELECT A.[IdAluno] AS IdAluno
					  FROM [dbo].[Alunos] AS A";

        public async Task<LoginResponseDTO> GetLogin(LoginRequestDTO loginDTO)
        {
            try
            {
                using (IDbConnection connection = Connection)
                {
                    sql = @$"SELECT U.IdUsuario AS IdUsuario
                                  , TU.CdTipoUsuario AS CdTipoUsuario
                                  , TU.TxTipoUsuario AS TxTipoUsuario
                                  , E.IdEscola AS IdEscola
                                  , A.IdAluno AS IdAluno
                                  , A.NmAluno AS NmAluno
                                  , A.SbnmAluno AS SbnmAluno
                             FROM Usuarios AS U
		                     INNER JOIN TipoUsuarios AS TU ON U.IdTipoUsuario = TU.IdTipoUsuario
                             LEFT JOIN Escolas AS E ON U.IdEscola = E.IdEscola
		                     LEFT JOIN Alunos AS A ON U.IdUsuario = A.IdUsuario
		                     LEFT JOIN Matriculas AS M ON M.IdMatricula = A.IdMatricula
                             WHERE (U.TxEmail = '{loginDTO.TxLogin}' OR M.NuMatricula = '{loginDTO.TxLogin}') AND U.TxSenha = '{loginDTO.TxSenha}'";

                    var result = await connection.QueryFirstOrDefaultAsync<LoginResponseDTO>(sql, null);

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
