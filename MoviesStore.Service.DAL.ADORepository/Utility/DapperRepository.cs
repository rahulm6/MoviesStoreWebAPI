using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

using System.ComponentModel;
using System.Data.Common;

namespace MoviesStore.Service.DAL.ADORepository
{
    public class DapperRepository : IDapperRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static IDbConnection OpenConnection(string providerName, string connectionString)
        {
            IDbConnection connection = DbProviderFactories.GetFactory(providerName).CreateConnection();
            connection.ConnectionString = connectionString;
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            return connection;
        }
        public List<T> ExecuteQuery<T>(string Query, string providerName, string connectionString, int? commandTimeout=null)
        {
            using (IDbConnection connection = OpenConnection(providerName, connectionString))
            {
                var result = connection.Query<T>(Query, commandTimeout: commandTimeout);
                return result.ToList();
            }
        }

        public List<TReturn> ExecuteQuery<TFirst, TSecond, TReturn>(string Query, Func<TFirst, TSecond, TReturn> map, string providerName, string connectionString, string splitOn)
        {
            using (IDbConnection connection = OpenConnection(providerName, connectionString))
            {
                var result = connection.Query<TFirst, TSecond, TReturn>(Query, map, commandType: CommandType.StoredProcedure, splitOn: splitOn);
                return result.ToList();
            }
        }
        public List<TReturn> ExecuteQuery<TFirst, TSecond, TReturn>(string Query, Func<TFirst, TSecond, TReturn> map, DynamicParameters DP, string providerName, string connectionString, string splitOn)
        {
            using (IDbConnection connection = OpenConnection(providerName, connectionString))
            {
                var result = connection.Query<TFirst, TSecond, TReturn>(Query, map, DP, commandType: CommandType.StoredProcedure, splitOn: splitOn);
                return result.ToList();
            }
        }

        public List<TReturn> ExecuteQuery<TFirst, TSecond, TReturn>(string Query, Func<TFirst, TSecond, TReturn> map, string providerName, string connectionString)
        {
            using (IDbConnection connection = OpenConnection(providerName, connectionString))
            {
                var result = connection.Query<TFirst, TSecond, TReturn>(Query, map);
                return result.ToList();
            }
        }
        public List<TReturn> ExecuteQuery<TFirst, TSecond, TReturn>(string Query, Func<TFirst, TSecond, TReturn> map, DynamicParameters DP, string providerName, string connectionString)
        {
            using (IDbConnection connection = OpenConnection(providerName, connectionString))
            {
                var result = connection.Query<TFirst, TSecond, TReturn>(Query, map, DP);
                return result.ToList();
            }
        }        
        public List<TReturn> ExecuteQuery<TFirst, TSecond, TThird, TReturn>(DynamicParameters DP, string Query, Func<TFirst, TSecond, TThird, TReturn> map, string providerName, string connectionString)
        {
            using (IDbConnection connection = OpenConnection(providerName, connectionString))
            {
                var result = connection.Query<TFirst, TSecond, TThird, TReturn>(Query, map, DP);
                return result.ToList();
            }
        }     
        public List<T> ExecuteQuery<T>(DynamicParameters DP, string Query, string providerName, string connectionString)
        {
            using (IDbConnection connection = OpenConnection(providerName, connectionString))
            {
                var result = connection.Query<T>(Query, DP);
                return result.ToList();
            }
        }
        public List<T> QueryOnExistingConnection<T>(DynamicParameters DP, string Query, IDbConnection connection = null)
        {
            var result = connection.Query<T>(Query, DP);
            return result.ToList();
        }
        public List<T> ExecuteStoredProcedure<T>(DynamicParameters DP, string Query,string providerName, string connectionString)
        {
            using (IDbConnection connection = OpenConnection(providerName, connectionString))
            {
                var result = connection.Query<T>(Query, DP, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }

        public object ExecuteScalarQuery(DynamicParameters DP, string Query, string providerName, string connectionString)
        {
            using (IDbConnection connection = OpenConnection(providerName, connectionString))
            {
                return connection.ExecuteScalar(Query, DP, commandType: CommandType.StoredProcedure);
            }
        }

        public object ExecuteScalarStoredProcedure(DynamicParameters DP, string Query, string providerName, string connectionString)
        {
            using (IDbConnection connection = OpenConnection(providerName, connectionString))
            {
                return connection.ExecuteScalar(Query, DP, commandType: CommandType.StoredProcedure);
            }
        }

        public T QueryMultiple<T> (string Query, DynamicParameters dp, Func<SqlMapper.GridReader, T> ObjectMapping , string providerName, string connectionString)
        {
            using (IDbConnection connection = OpenConnection(providerName, connectionString))
            {
                SqlMapper.GridReader result = connection.QueryMultiple(Query, param: dp, commandType: CommandType.StoredProcedure);
                return ObjectMapping(result);
            }
        }
        public bool ExecuteStoredProcedure(string Query, string providerName, string connectionString)
        {
            using (IDbConnection connection = OpenConnection(providerName, connectionString))
            {
                var result = connection.Execute(Query, commandType: CommandType.StoredProcedure);
                return true;
            }
        }
        public int ExecuteStoredProcedure(string Query, DynamicParameters dp, string providerName, string connectionString)
        {
            using (IDbConnection connection = OpenConnection(providerName, connectionString))
            {
                var result = connection.Execute(Query, dp, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
        public List<T> ExecuteStoredProcedure<T>(string Query, DynamicParameters dp, string providerName, string connectionString)
        {
            using (IDbConnection connection = OpenConnection(providerName, connectionString))
            {
                var result = connection.Query<T>(Query, param: dp, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }
        public List<TReturn> ExecuteStoredProcedure<TFirst, TSecond, TReturn>(string Query, Func<TFirst, TSecond, TReturn> map, DynamicParameters DP, string splitOn, string providerName, string connectionString)
        {
            using (IDbConnection connection = OpenConnection(providerName, connectionString))
            {
                var result = connection.Query<TFirst, TSecond, TReturn>(Query, map, DP, commandType: CommandType.StoredProcedure,splitOn:splitOn);
                return result.ToList();
            }
        }
        public List<TReturn> ExecuteStoredProcedure<TFirst, TSecond, TThird, TReturn>(string Query, Func<TFirst, TSecond, TThird, TReturn> map, DynamicParameters DP, string splitOn, string providerName, string connectionString)
        {
            using (IDbConnection connection = OpenConnection(providerName, connectionString))
            {
                var result = connection.Query<TFirst, TSecond, TThird, TReturn>(Query, map, DP, commandType: CommandType.StoredProcedure, splitOn: splitOn);
                return result.ToList();
            }
        }
        public DataTable GetData(IDbCommand cmd, string providerName)
        {
            DataSet result;
            IDbDataAdapter da;
            try
            {
                da = DbProviderFactories.GetFactory(providerName).CreateDataAdapter();
                da.SelectCommand = cmd;
                result = new DataSet();
                da.Fill(result);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
            }
            return result.Tables[0];
        }
        private DataTable ConvertToDataTable<T>(IList<T> list)
        {
            PropertyDescriptorCollection propertyDescriptorCollection = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            for (int i = 0; i < propertyDescriptorCollection.Count; i++)
            {
                PropertyDescriptor propertyDescriptor = propertyDescriptorCollection[i];
                Type propType = propertyDescriptor.PropertyType;
                if (propType.IsGenericType && propType.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    table.Columns.Add(propertyDescriptor.Name, Nullable.GetUnderlyingType(propType));
                }
                else
                {
                    table.Columns.Add(propertyDescriptor.Name, propType);
                }
            }
            object[] values = new object[propertyDescriptorCollection.Count];
            foreach (T listItem in list)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = propertyDescriptorCollection[i].GetValue(listItem);
                }
                table.Rows.Add(values);
            }
            return table;
        }
        public bool SqlTruncateAndBulkInsert<T>(IList<T> list, List<SqlBulkCopyColumnMapping> columnMappings, string destinationTableName, string providerName, string connectionString)
        {
            
            try
            {
                DataTable dt = ConvertToDataTable<T>(list);
                SqlTransaction transaction;
                using (SqlConnection connection = OpenConnection(providerName, connectionString) as SqlConnection)
                {
                    using (transaction = connection.BeginTransaction())
                    {
                        connection.Query(" TRUNCATE TABLE " + destinationTableName, transaction: transaction);
                        using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(connection, SqlBulkCopyOptions.Default, transaction))
                        {
                            foreach (SqlBulkCopyColumnMapping item in columnMappings)
                            {
                                sqlBulkCopy.ColumnMappings.Add(item);
                            }
                            sqlBulkCopy.DestinationTableName = destinationTableName;

                            sqlBulkCopy.WriteToServer(dt);

                            transaction.Commit();
                        }
                    }
                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {

            }
        }

        public List<T> ExecuteStoredProcedure<T>(string Query, string providerName, string connectionString)
        {
            using (IDbConnection connection = OpenConnection(providerName, connectionString))
            {
                var result = connection.Query<T>(Query, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }
    }
}
