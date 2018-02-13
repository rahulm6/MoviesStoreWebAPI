using MoviesStore.Service.Common.Entity.DataModel;
using MoviesStore.Service.Common.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesStore.Service.DAL.ADORepository.Utility
{
    public static class RepositoryHelper
    {
        public static IDbConnection OpenConnection(string providerName, string connectionString)
        {
            IDbConnection connection = DbProviderFactories.GetFactory(providerName).CreateConnection();
            connection.ConnectionString = connectionString;
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            return connection;
        }
        public static List<SqlParameter> CreateSqlParameters(Movie movie)
        {
            List<SqlParameter> parameters = new List<SqlParameter>() 
            {
                new SqlParameter(){ParameterName = "@MovieID", SqlDbType = System.Data.SqlDbType.VarChar, Size = 800, Direction = System.Data.ParameterDirection.InputOutput,Value = movie.MovieID },
                new SqlParameter(){ParameterName = "@Name", SqlDbType = System.Data.SqlDbType.VarChar, Size = 800, Value = movie.Name},
                new SqlParameter(){ParameterName = "@YearOfRelease", SqlDbType = System.Data.SqlDbType.VarChar, Size = 800,Value = movie.YearOfRelease ,IsNullable = true},
                new SqlParameter(){ParameterName = "@Plot", SqlDbType = System.Data.SqlDbType.VarChar, Size = 4000, Value = movie.Plot,IsNullable = true },
                new SqlParameter(){ParameterName = "@Poster", SqlDbType = System.Data.SqlDbType.VarChar, Size = 800, Value = movie.Poster,IsNullable = true},
                new SqlParameter(){ParameterName = "@ProducerID", SqlDbType = System.Data.SqlDbType.Int, Size = 800, Value = movie.ProducerID,IsNullable = true },
                new SqlParameter(){ParameterName = "@Actors", SqlDbType = System.Data.SqlDbType.Structured, Value = GetActorsDataTable(movie.Actors) }
            };

            return parameters;
        }

        public static List<SqlParameter> CreateActorSqlParameters(Actor actor)
        {
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter(){ParameterName = "@ActorID", SqlDbType = System.Data.SqlDbType.Int, Size = 800, Direction = System.Data.ParameterDirection.InputOutput,Value = actor.ActorID },
                new SqlParameter(){ParameterName = "@Name", SqlDbType = System.Data.SqlDbType.VarChar, Size = 800, Value = actor.Name},
                new SqlParameter(){ParameterName = "@Sex", SqlDbType = System.Data.SqlDbType.VarChar, Value =  actor.Sex,IsNullable = true},
                new SqlParameter(){ParameterName = "@DOB", SqlDbType = System.Data.SqlDbType.DateTime, Size = 4000, Value = actor.DOB.Value.ToString("yyyy-MM-dd HH:mm:ss.fffffff", CultureInfo.InvariantCulture),IsNullable = true },
                new SqlParameter(){ParameterName = "@Bio", SqlDbType = System.Data.SqlDbType.VarChar, Size = 800, Value = actor.Bio,IsNullable = true}
            };

            return parameters;
        }

        public static List<SqlParameter> CreateProducerSqlParameters(Producer producer)
        {
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter(){ParameterName = "@ProducerID", SqlDbType = System.Data.SqlDbType.VarChar, Size = 800, Direction = System.Data.ParameterDirection.InputOutput,Value = producer.ProducerID },
                new SqlParameter(){ParameterName = "@Name", SqlDbType = System.Data.SqlDbType.VarChar, Size = 800, Value = producer.Name},
                new SqlParameter(){ParameterName = "@Sex", SqlDbType = System.Data.SqlDbType.VarChar, Size = 4000,Value =  producer.Sex,IsNullable = true},
                new SqlParameter(){ParameterName = "@DOB", SqlDbType = System.Data.SqlDbType.DateTime,  Value = producer.DOB.Value.ToString("yyyy-MM-dd HH:mm:ss.fffffff", CultureInfo.InvariantCulture),IsNullable = true },
                new SqlParameter(){ParameterName = "@Bio", SqlDbType = System.Data.SqlDbType.VarChar, Size = 800, Value = producer.Bio,IsNullable = true}
            };

            return parameters;
        }

        private static DataTable GetActorsDataTable(List<Actor> actors)
        {
            var dt = MasterDataManager.ActorDataTable;

            dt.Rows.Clear();

            foreach (var item in actors)
            {
                var data = dt.NewRow();

                data["ActorID"] = item.ActorID;
                data["Name"] = item.Name ?? (object)DBNull.Value;
                data["Sex"] = item.Sex ?? (object)DBNull.Value;
                data["Bio"] = item.Bio ?? (object)DBNull.Value;
                data["DOB"] = item.DOB ?? (object)DBNull.Value;
                dt.Rows.Add(data);
            }

            return dt;
        }
    }

   
}
