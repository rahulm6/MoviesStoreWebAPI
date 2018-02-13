using MoviesStore.Service.DAL.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoviesStore.Service.Common.Entity.Data_Model;

namespace MoviesStore.Service.DAL.ADORepository
{
    public class MasterDataRepository : IMasterDataRepository
    {
        IDapperRepository _DapperRepository = null;

        #region Constructor initialization

        /// <summary>
        /// Contructor to Intialize the Dapper Repository.
        /// </summary>
        /// <param name="dapperRepository"> Parameter to Intialize </param>
        public MasterDataRepository(IDapperRepository dapperRepository)
        {
            _DapperRepository = dapperRepository;
        }

        /// <summary>
        /// Contructor to Intialize the Dapper Repository.
        /// </summary>
        /// <param name="dapperRepository"> Parameter to Intialize </param>
        public MasterDataRepository()
        {
            // TODO: Complete member initialization
        }

        #endregion
        public List<Year> GetAllYears(string spName, string providerName, string connectionString)
        {
            try
            {


                return _DapperRepository.ExecuteStoredProcedure<Year>(spName
                , providerName, connectionString).ToList();
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
    }
}
