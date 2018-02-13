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
    public class ActorManager : IActorManager
    {
        private readonly IActorRepository _actorRepository;


        #region Constructor initialization


        public ActorManager(IActorRepository _actorRepository)
        {
            this._actorRepository = _actorRepository;
        }

        /// <summary>
        /// Constructor to Initialize the DAL Repository and Facade
        /// </summary>
        public ActorManager()
        {
            // TODO: Complete member initialization
        }

        #endregion
        public List<Actor> GetAllActors()
        {
            string connectionString = Utility.Util.GetConnectionString(MoviesStore.Service.Common.Util.MasterDataManager.ConfigData["MoviesStoreDb"]);
            string providerName = Utility.Util.GetProviderName(MoviesStore.Service.Common.Util.MasterDataManager.ConfigData["MoviesStoreDb"]);
            string spName = MoviesStore.Service.Common.Util.MasterDataManager.ConfigData["GetAllActors"];

            try
            {
                return _actorRepository.GetAllActors(spName, providerName, connectionString);
            }
            catch (Exception e)
            {

                throw e.InnerException;
            }
        }

        public Actor AddActor(Actor actor)
        {
            string connectionString = Utility.Util.GetConnectionString(MoviesStore.Service.Common.Util.MasterDataManager.ConfigData["MoviesStoreDb"]);
            string providerName = Utility.Util.GetProviderName(MoviesStore.Service.Common.Util.MasterDataManager.ConfigData["MoviesStoreDb"]);
            string spName = MoviesStore.Service.Common.Util.MasterDataManager.ConfigData["AddActor"];

            try
            {
                return _actorRepository.AddActor(actor, spName, providerName, connectionString);
            }
            catch (Exception e)
            {

                throw e.InnerException;
            }
        }
    }
}
