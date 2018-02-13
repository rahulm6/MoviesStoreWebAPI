using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoviesStore.Service.Common.Entity.Data_Model;
using MoviesStore.Service.DAL.IRepository;

namespace MoviesStore.Service.BL
{
    public class MasterDataManager : IMasterDataManager
    {
        private readonly IMasterDataRepository _masterRepository;


        #region Constructor initialization


        public MasterDataManager(IMasterDataRepository _masterRepository)
        {
            this._masterRepository = _masterRepository;
        }

        /// <summary>
        /// Constructor to Initialize the DAL Repository and Facade
        /// </summary>
        public MasterDataManager()
        {
            // TODO: Complete member initialization
        }

        #endregion
        public List<Year> GetAllYears()
        {
            string connectionString = Utility.Util.GetConnectionString(MoviesStore.Service.Common.Util.MasterDataManager.ConfigData["MoviesStoreDb"]);
            string providerName = Utility.Util.GetProviderName(MoviesStore.Service.Common.Util.MasterDataManager.ConfigData["MoviesStoreDb"]);
            string spName = MoviesStore.Service.Common.Util.MasterDataManager.ConfigData["GetAllYears"];

            try
            {
                return _masterRepository.GetAllYears(spName, providerName, connectionString);
            }
            catch (Exception e)
            {

                throw e.InnerException;
            }
        }
    }
}
