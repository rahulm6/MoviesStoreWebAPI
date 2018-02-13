using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoviesStore.Service.Common.Entity.DataModel;
using MoviesStore.Service.DAL.IRepository;
using MoviesStore.Service.Common.Util;

namespace MoviesStore.Service.BL
{
    public class ProducerManager : IProducerManager
    {
        private readonly IProducerRepository _producerRepository;


        #region Constructor initialization


        public ProducerManager(IProducerRepository _producerRepository)
        {
            this._producerRepository = _producerRepository;
        }

        /// <summary>
        /// Constructor to Initialize the DAL Repository and Facade
        /// </summary>
        public ProducerManager()
        {
            // TODO: Complete member initialization
        }

        #endregion
        public List<Producer> GetAllProducers()
        {
            string connectionString = Utility.Util.GetConnectionString(MoviesStore.Service.Common.Util.MasterDataManager.ConfigData["MoviesStoreDb"]);
            string providerName = Utility.Util.GetProviderName(MoviesStore.Service.Common.Util.MasterDataManager.ConfigData["MoviesStoreDb"]);
            string spName = MoviesStore.Service.Common.Util.MasterDataManager.ConfigData["GetAllProducers"];

            try
            {
                return _producerRepository.GetAllProducers(spName, providerName, connectionString);
            }
            catch (Exception e)
            {

                throw e.InnerException;
            }
        }

        public Producer AddProducer(Producer producer)
        {
            string connectionString = Utility.Util.GetConnectionString(MoviesStore.Service.Common.Util.MasterDataManager.ConfigData["MoviesStoreDb"]);
            string providerName = Utility.Util.GetProviderName(MoviesStore.Service.Common.Util.MasterDataManager.ConfigData["MoviesStoreDb"]);
            string spName = MoviesStore.Service.Common.Util.MasterDataManager.ConfigData["AddProducer"];

            try
            {
                return _producerRepository.AddProducer(producer, spName, providerName, connectionString);
            }
            catch (Exception e)
            {

                throw e.InnerException;
            }
        }
    }
}
