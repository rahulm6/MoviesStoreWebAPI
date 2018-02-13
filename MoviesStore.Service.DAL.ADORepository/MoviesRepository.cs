using MoviesStore.Service.DAL.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoviesStore.Service.Common.Entity.DataModel;
using Dapper;
using System.Data;
using System.Data.Common;
using MoviesStore.Service.DAL.ADORepository.Utility;
using MoviesStore.Service.Common.Util;
using System.Data.SqlClient;

namespace MoviesStore.Service.DAL.ADORepository
{
    public class MoviesRepository : IMoviesRepository
    {
        IDapperRepository _DapperRepository = null;

        #region Constructor initialization

        /// <summary>
        /// Contructor to Intialize the Dapper Repository.
        /// </summary>
        /// <param name="dapperRepository"> Parameter to Intialize </param>
        public MoviesRepository(IDapperRepository dapperRepository)
        {
            _DapperRepository = dapperRepository;
        }

        /// <summary>
        /// Contructor to Intialize the Dapper Repository.
        /// </summary>
        /// <param name="dapperRepository"> Parameter to Intialize </param>
        public MoviesRepository()
        {
            // TODO: Complete member initialization
        }

        #endregion
        public List<Movie> GetAllMovies(string spName, string providerName, string connectionString)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                //var list = _DapperRepository.ExecuteStoredProcedure<Movie>(spName, providerName, connectionString);
                var lookup = new Dictionary<int, Movie>();
                //return list.ToList();
                //var movies= _DapperRepository.ExecuteStoredProcedure<Movie, Producer,Actor, Movie>(spName, (movie, producer,actor) =>
                //{
                //    movie.Producer = producer;

                //    if (movie.Actors == null)
                //        movie.Actors = new List<Actor>();
                //    movie.Actors.Add(actor);
                //    return movie;
                //}, parameters, "ProducerID,ActorID", providerName, connectionString);
                IDbConnection connection = DbProviderFactories.GetFactory(providerName).CreateConnection();
                connection.ConnectionString = connectionString;
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                
                connection.Query<Movie, Producer,Actor, Movie>(spName, (m,p,a) =>
                {
                    Movie movie;
                    
                    if (!lookup.TryGetValue(m.MovieID, out movie))
                        lookup.Add(m.MovieID, movie = m);

                    if (movie.Actors == null)
                        movie.Actors = new List<Actor>();

                    movie.Actors.Add(a);
                    movie.Producer = p;

                    return movie;
                }, splitOn: "ProducerID,ActorID").AsQueryable();

                var movs = lookup.Values.ToList();
                return movs;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Movie AddMovie(Movie movie, string spName, string providerName, string connectionString)
        {
            try
            {
                var parameters = RepositoryHelper.CreateSqlParameters(movie);
                var paramsArray = parameters.ToArray();

                string storedProcedure = MasterDataManager.ConfigData["AddMovie"];
                using (SqlConnection connection = (SqlConnection)RepositoryHelper.OpenConnection(providerName, connectionString))
                {
                    try
                    {
                        var sqlCommand = new SqlCommand()
                        {
                            Connection = connection,
                            CommandText = storedProcedure,
                            CommandType = CommandType.StoredProcedure
                        };
                        sqlCommand.Parameters.AddRange(paramsArray);
                        sqlCommand.ExecuteNonQuery();
                        movie.MovieID = Convert.ToInt32((paramsArray.FirstOrDefault(a => a.ParameterName == "@MovieID").Value.ToString()));
                        
                    }
                    catch (System.Exception ex)
                    {
                        throw;
                    }
                    finally
                    {
                        connection.Close();
                    }
                }

                
            }
            catch (System.Exception ex)
            {
                throw;
            }

            return movie;
        }

        public Movie GetMovieByID(int ID, string spName, string providerName, string connectionString)
        {
            try
            {
                dynamic input = new
                {
                    ID = ID
                };
                //var list = _DapperRepository.ExecuteStoredProcedure<Movie>(spName, providerName, connectionString);
                var lookup = new Dictionary<int, Movie>();

                IDbConnection connection = DbProviderFactories.GetFactory(providerName).CreateConnection();
                connection.ConnectionString = connectionString;
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                connection.Query<Movie, Producer, Actor, Movie>(spName, (m, p, a) =>
                {
                    Movie movie;

                    if (!lookup.TryGetValue(m.MovieID, out movie))
                        lookup.Add(m.MovieID, movie = m);

                    if (movie.Actors == null)
                        movie.Actors = new List<Actor>();

                    movie.Actors.Add(a);
                    movie.Producer = p;

                    return movie;
                }, new { ID=ID},splitOn: "ProducerID,ActorID",commandType:CommandType.StoredProcedure).AsQueryable();

                var movs = lookup.Values.ToList();
                return movs.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Movie EditMovie(Movie movie, string spName, string providerName, string connectionString)
        {
            try
            {
                var parameters = RepositoryHelper.CreateSqlParameters(movie);
                var paramsArray = parameters.ToArray();

                
                using (SqlConnection connection = (SqlConnection)RepositoryHelper.OpenConnection(providerName, connectionString))
                {
                    try
                    {
                        var sqlCommand = new SqlCommand()
                        {
                            Connection = connection,
                            CommandText = spName,
                            CommandType = CommandType.StoredProcedure
                        };
                        sqlCommand.Parameters.AddRange(paramsArray);
                        sqlCommand.ExecuteNonQuery();
                        //movie.MovieID = Convert.ToInt32((paramsArray.FirstOrDefault(a => a.ParameterName == "@MovieID").Value.ToString()));

                    }
                    catch (System.Exception ex)
                    {
                        throw;
                    }
                    finally
                    {
                        connection.Close();
                    }
                }


            }
            catch (System.Exception ex)
            {
                throw;
            }

            return movie;
        }
    }
}
