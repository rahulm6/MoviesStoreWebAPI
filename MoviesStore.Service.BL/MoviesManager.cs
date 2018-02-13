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
    public class MoviesManager : IMoviesManager
    {
        private readonly IMoviesRepository _movieRepository;

        
        #region Constructor initialization

       
        public MoviesManager(IMoviesRepository _movieRepository)
        {
            this._movieRepository = _movieRepository;
        }

        /// <summary>
        /// Constructor to Initialize the DAL Repository and Facade
        /// </summary>
        public MoviesManager()
        {
            // TODO: Complete member initialization
        }

        #endregion
        public List<Movie> GetAllMovies()
        {
            string connectionString = Utility.Util.GetConnectionString(MoviesStore.Service.Common.Util.MasterDataManager.ConfigData["MoviesStoreDb"]);
            string providerName = Utility.Util.GetProviderName(MoviesStore.Service.Common.Util.MasterDataManager.ConfigData["MoviesStoreDb"]);
            string spName = MoviesStore.Service.Common.Util.MasterDataManager.ConfigData["GetAllMovies"];

            try
            {
                return _movieRepository.GetAllMovies(spName, providerName, connectionString);
            }
            catch (Exception e)
            {

                throw e.InnerException;
            }
        }

        public Movie AddMovie(Movie movie)
        {
            string connectionString = Utility.Util.GetConnectionString(MoviesStore.Service.Common.Util.MasterDataManager.ConfigData["MoviesStoreDb"]);
            string providerName = Utility.Util.GetProviderName(MoviesStore.Service.Common.Util.MasterDataManager.ConfigData["MoviesStoreDb"]);
            string spName = MoviesStore.Service.Common.Util.MasterDataManager.ConfigData["AddMovie"];

            try
            {
                return _movieRepository.AddMovie(movie,spName, providerName, connectionString);
            }
            catch (Exception e)
            {

                throw e.InnerException;
            }
        }

        public Movie GetMovieByID(int ID)
        {
            string connectionString = Utility.Util.GetConnectionString(MoviesStore.Service.Common.Util.MasterDataManager.ConfigData["MoviesStoreDb"]);
            string providerName = Utility.Util.GetProviderName(MoviesStore.Service.Common.Util.MasterDataManager.ConfigData["MoviesStoreDb"]);
            string spName = MoviesStore.Service.Common.Util.MasterDataManager.ConfigData["GetMovieByID"];

            try
            {
                return _movieRepository.GetMovieByID(ID, spName, providerName, connectionString);
            }
            catch (Exception e)
            {

                throw e.InnerException;
            }
        }

        public Movie EditMovie(Movie movie)
        {
            string connectionString = Utility.Util.GetConnectionString(MoviesStore.Service.Common.Util.MasterDataManager.ConfigData["MoviesStoreDb"]);
            string providerName = Utility.Util.GetProviderName(MoviesStore.Service.Common.Util.MasterDataManager.ConfigData["MoviesStoreDb"]);
            string spName = MoviesStore.Service.Common.Util.MasterDataManager.ConfigData["EditMovie"];

            try
            {
                return _movieRepository.EditMovie(movie, spName, providerName, connectionString);
            }
            catch (Exception e)
            {

                throw e.InnerException;
            }
        }
    }
}
