using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoviesStore.Service.Common.Entity.DataModel;
using MoviesStore.Service.DAL.IRepository;
using MoviesStore.Service.DAL.ADORepository.Utility;
using System.Data.SqlClient;
using MoviesStore.Service.Common.Util;
using System.Data;

namespace MoviesStore.Service.DAL.ADORepository
{
    public class ActorRepository : IActorRepository
    {
        IDapperRepository _DapperRepository = null;

        #region Constructor initialization

        /// <summary>
        /// Contructor to Intialize the Dapper Repository.
        /// </summary>
        /// <param name="dapperRepository"> Parameter to Intialize </param>
        public ActorRepository(IDapperRepository dapperRepository)
        {
            _DapperRepository = dapperRepository;
        }

        /// <summary>
        /// Contructor to Intialize the Dapper Repository.
        /// </summary>
        /// <param name="dapperRepository"> Parameter to Intialize </param>
        public ActorRepository()
        {
            // TODO: Complete member initialization
        }

        #endregion
        public List<Actor> GetAllActors(string spName, string providerName, string connectionString)
        {
            try
            {


                return _DapperRepository.ExecuteStoredProcedure<Actor>(spName
                , providerName, connectionString).ToList();
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        public Actor AddActor(Actor actor, string spName, string providerName, string connectionString)
        {
            try
            {
                var parameters = RepositoryHelper.CreateActorSqlParameters(actor);
                var paramsArray = parameters.ToArray();

                string storedProcedure = MasterDataManager.ConfigData["AddActor"];
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
                        actor.ActorID = Convert.ToInt32((paramsArray.FirstOrDefault(a => a.ParameterName == "@ActorID").Value.ToString()));

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

            return actor;
        }
    }
}
