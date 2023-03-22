using Canducci.Pagination;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministrativoEscolar.READ.Queries.Base
{
    public static class Query
    {
        // Generic Get
        public static List<T> GetAll<T>(this IDbConnection connect, string query, Object parametros)
        {
            try
            {
                connect.Open();
                return connect.Query<T>(query, parametros).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connect.Close();
            }
        }

        // Generic GetAll
        public static async Task<IEnumerable<T>> GetAsyncAll<T>(this IDbConnection connect, string query, Object parametros)
        {
            try
            {
                connect.Open();
                var result = await connect.QueryAsync<T>(query, parametros);

                return result;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connect.Close();
            }
        }

        // Generic GetAll
        //Metodo para abstracao da query paginacao
        public static async Task<PaginatedRest<T>> GetPaginationAsyncAll<T, U>(this IDbConnection connect, string query, U param, int PageNumber, int PageSize) //param deve ser generico (T)
        {
            try
            {
                connect.Open();

                var reader = await connect.QueryMultipleAsync(query, param);

                var result = reader.Read<T>();

                if (PageNumber <= 0) PageNumber = 1;

                return await result.ToPaginatedRestAsync(PageNumber, PageSize); ;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connect.Close();
            }
        }


        // Generic GetById
        public static async Task<T> GetAsyncById<T>(this IDbConnection connect, string query, Object parametros)
        {
            try
            {
                connect.Open();
                return await connect.QueryFirstOrDefaultAsync<T>(query, parametros);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connect.Close();
            }
        }
    }
}
