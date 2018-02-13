using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoviesStore.Service.Common.Entity.DataModel;
using MoviesStore.Service.DAL.IRepository;
using MoviesStore.Service.DAL.ADORepository.Utility;
using MoviesStore.Service.Common.Util;
using System.Data.SqlClient;
using System.Data;

namespace MoviesStore.Service.DAL.ADORepository
{
    public class ProducerRepository : IProducerRepository
    {
        IDapperRepository _DapperRepository = null;

        #region Constructor initialization

        /// <summary>
        /// Contructor to Intialize the Dapper Repository.
        /// </summary>
        /// <param name="dapperRepository"> Parameter to Intialize </param>
        public ProducerRepository(IDapperRepository dapperRepository)
        {
            _DapperRepository = dapperRepository;
        }

        /// <summary>
        /// Contructor to Intialize the Dapper Repository.
        /// </summary>
        /// <param name="dapperRepository"> Parameter to Intialize </param>
        public ProducerRepository()
        {
            // TODO: Complete member initialization
        }

        #endregion
        public List<Producer> GetAllProducers(string spName, string providerName, string connectionString)
        {
            try
            {

                
                return _DapperRepository.ExecuteStoredProcedure<Producer>(spName
                , providerName, connectionString).ToList();
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        public Producer AddProducer(Producer producer, string spName, string providerName, string connectionString)
        {
            try
            {
                var parameters = RepositoryHelper.CreateProducerSqlParameters(producer);
                var paramsArray = parameters.ToArray();

                string storedProcedure = MasterDataManager.ConfigData["AddProducer"];
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
                        producer.ProducerID = Convert.ToInt32((paramsArray.FirstOrDefault(a => a.ParameterName == "@ProducerID").Value.ToString()));

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

            return producer;
        }
    }
}
