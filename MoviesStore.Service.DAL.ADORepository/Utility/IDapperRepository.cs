using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesStore.Service.DAL.ADORepository
{
    public interface IDapperRepository
    {
        List<T> ExecuteQuery<T>(string Query, string providerName, string connectionString, int? commandTimeout = null);

        List<TReturn> ExecuteQuery<TFirst, TSecond, TReturn>(string Query, Func<TFirst, TSecond, TReturn> map, string providerName, string connectionString, string splitOn);

        List<TReturn> ExecuteQuery<TFirst, TSecond, TReturn>(string Query, Func<TFirst, TSecond, TReturn> map, DynamicParameters DP, string providerName, string connectionString, string splitOn);

        List<TReturn> ExecuteQuery<TFirst, TSecond, TReturn>(string Query, Func<TFirst, TSecond, TReturn> map, string providerName, string connectionString);

        List<TReturn> ExecuteQuery<TFirst, TSecond, TReturn>(string Query, Func<TFirst, TSecond, TReturn> map, DynamicParameters DP, string providerName, string connectionString);
        List<TReturn> ExecuteQuery<TFirst, TSecond, TThird, TReturn>(DynamicParameters DP, string Query, Func<TFirst, TSecond, TThird, TReturn> map, string providerName, string connectionString);
        List<T> ExecuteQuery<T>(DynamicParameters DP, string Query, string providerName, string connectionString);
        List<T> QueryOnExistingConnection<T>(DynamicParameters DP, string Query, IDbConnection connection = null);
        T QueryMultiple<T>(string Query, DynamicParameters dp, Func<SqlMapper.GridReader, T> ObjectMapping, string providerName, string connectionString);
        int ExecuteStoredProcedure(string Query, DynamicParameters dp, string providerName, string connectionString);
        bool ExecuteStoredProcedure(string Query, string providerName, string connectionString);
        List<T> ExecuteStoredProcedure<T>(string Query, DynamicParameters dp, string providerName, string connectionString);
        List<T> ExecuteStoredProcedure<T>(string Query, string providerName, string connectionString);
        object ExecuteScalarQuery(DynamicParameters DP, string Query, string providerName, string connectionString);
        object ExecuteScalarStoredProcedure(DynamicParameters DP, string Query, string providerName, string connectionString);
        List<TReturn> ExecuteStoredProcedure<TFirst, TSecond, TReturn>(string Query, Func<TFirst, TSecond, TReturn> map, DynamicParameters DP, string splitOn, string providerName, string connectionString);
        List<TReturn> ExecuteStoredProcedure<TFirst, TSecond, TThird, TReturn>(string Query, Func<TFirst, TSecond, TThird, TReturn> map, DynamicParameters DP, string splitOn, string providerName, string connectionString);
        List<T> ExecuteStoredProcedure<T>(DynamicParameters DP, string Query, string providerName, string connectionString);
        DataTable GetData(IDbCommand cmd, string providerName);

        bool SqlTruncateAndBulkInsert<T>(IList<T> list, List<SqlBulkCopyColumnMapping> columnMappings, string destinationTableName, string providerName, string connectionString);
    }
}
