
using MoviesStore.Web.Service.Facade.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesStore.Web.Service.Facade
{
    public class ExternalService : IExternalService
    {
        public ExternalService()
        {

        }

        public ActorDTO AddActor(ActorDTO actor)
        {
            try
            {
                string baseAddress = ConfigurationManager.AppSettings["MovieService"].ToString();//MasterDataManager.ConfigData["MoviesStoreServiceURL"].ToString();
                string requestURI = "api/Actor/AddActor";//MasterDataManager.ConfigData["GetAllMoviesAPIURI"].ToString();

                //string[] acceptEncodings = null;
                //bool compressionFlag = false;

                Task<ActorDTO> actorResult = Task.Run(async () =>
                {
                    ActorDTO res = await Util.GetDataFromPostService<ActorDTO>(baseAddress, requestURI, actor, null, false);
                    return res;
                });
                return actorResult.Result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public MovieDTO AddMovie(MovieDTO movie)
        {

            try
            {
                string baseAddress = ConfigurationManager.AppSettings["MovieService"].ToString();//MasterDataManager.ConfigData["MoviesStoreServiceURL"].ToString();
                string requestURI = "api/Movie/AddMovie";//MasterDataManager.ConfigData["GetAllMoviesAPIURI"].ToString();

                //string[] acceptEncodings = null;
                //bool compressionFlag = false;

                Task<MovieDTO> movieResult = Task.Run(async () =>
                {
                    MovieDTO res = await Util.GetDataFromPostService<MovieDTO>(baseAddress, requestURI, movie, null, false);
                    return res;
                });
                return movieResult.Result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ProducerDTO AddProducer(ProducerDTO producer)
        {
            try
            {
                string baseAddress = ConfigurationManager.AppSettings["MovieService"].ToString();//MasterDataManager.ConfigData["MoviesStoreServiceURL"].ToString();
                string requestURI = "api/Producer/AddProducer";//MasterDataManager.ConfigData["GetAllMoviesAPIURI"].ToString();

                //string[] acceptEncodings = null;
                //bool compressionFlag = false;

                Task<ProducerDTO> producerResult = Task.Run(async () =>
                {
                    ProducerDTO res = await Util.GetDataFromPostService<ProducerDTO>(baseAddress, requestURI, producer, null, false);
                    return res;
                });
                return producerResult.Result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public MovieDTO EditMovie(MovieDTO movie)
        {
            try
            {
                string baseAddress = ConfigurationManager.AppSettings["MovieService"].ToString();// ConfigurationManager.AppSettings["MovieService"].ToString();//MasterDataManager.ConfigData["MoviesStoreServiceURL"].ToString();
                string requestURI = "api/Movie/EditMovie";//MasterDataManager.ConfigData["GetAllMoviesAPIURI"].ToString();

                //string[] acceptEncodings = null;
                //bool compressionFlag = false;

                Task<MovieDTO> movieResult = Task.Run(async () =>
                {
                    MovieDTO res = await Util.GetDataFromPostService<MovieDTO>(baseAddress, requestURI, movie, null, false);
                    return res;
                });
                return movieResult.Result;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public List<ActorDTO> GetAllActors()
        {
            try
            {
                string baseAddress = ConfigurationManager.AppSettings["MovieService"].ToString();//MasterDataManager.ConfigData["MoviesStoreServiceURL"].ToString();
                string requestURI = "api/Actor/GetAllActors";//MasterDataManager.ConfigData["GetAllMoviesAPIURI"].ToString();

                //string[] acceptEncodings = null;
                //bool compressionFlag = false;

                Task<List<ActorDTO>> actorResult = Task.Run(async () =>
                {
                    List<ActorDTO> res = await Util.GetDataFromService<List<ActorDTO>>(baseAddress, requestURI, null, false);
                    return res;
                });
                return actorResult.Result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<MovieDTO> GetAllMoviesList()
        {
            try
            {
                string baseAddress = ConfigurationManager.AppSettings["MovieService"].ToString();//MasterDataManager.ConfigData["MoviesStoreServiceURL"].ToString();
                string requestURI = "api/Movie/GetAllMovies";//MasterDataManager.ConfigData["GetAllMoviesAPIURI"].ToString();
                
                //string[] acceptEncodings = null;
                //bool compressionFlag = false;
                
                Task<List<MovieDTO>> movieResult = Task.Run(async () =>
                {
                    List<MovieDTO> res = await Util.GetDataFromService<List<MovieDTO>>(baseAddress, requestURI, null, false);
                    return res;
                });
                return movieResult.Result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ProducerDTO> GetAllProducers()
        {
            try
            {
                string baseAddress = ConfigurationManager.AppSettings["MovieService"].ToString();//MasterDataManager.ConfigData["MoviesStoreServiceURL"].ToString();
                string requestURI = "api/Producer/GetAllProducers";//MasterDataManager.ConfigData["GetAllMoviesAPIURI"].ToString();

                //string[] acceptEncodings = null;
                //bool compressionFlag = false;

                Task<List<ProducerDTO>> producerResult = Task.Run(async () =>
                {
                    List<ProducerDTO> res = await Util.GetDataFromService<List<ProducerDTO>>(baseAddress, requestURI, null, false);
                    return res;
                });
                return producerResult.Result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<YearDTO> GetAllYear()
        {
            try
            {
                string baseAddress = ConfigurationManager.AppSettings["MovieService"].ToString();//MasterDataManager.ConfigData["MoviesStoreServiceURL"].ToString();
                string requestURI = "api/MasterData/GetAllYears";//MasterDataManager.ConfigData["GetAllMoviesAPIURI"].ToString();

                //string[] acceptEncodings = null;
                //bool compressionFlag = false;

                Task<List<YearDTO>> yearResult = Task.Run(async () =>
                {
                    List<YearDTO> res = await Util.GetDataFromService<List<YearDTO>>(baseAddress, requestURI, null, false);
                    return res;
                });
                return yearResult.Result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public MovieDTO GetMovieByID(int ID)
        {
            try
            {
                string baseAddress = ConfigurationManager.AppSettings["MovieService"].ToString();//MasterDataManager.ConfigData["MoviesStoreServiceURL"].ToString();
                string requestURI = "api/Movie/GetMovieByID?ID=" + ID;//MasterDataManager.ConfigData["GetAllMoviesAPIURI"].ToString();

                //string[] acceptEncodings = null;
                //bool compressionFlag = false;

                Task<MovieDTO> movieResult = Task.Run(async () =>
                {
                    MovieDTO res = await Util.GetDataFromService<MovieDTO>(baseAddress, requestURI, null, false);
                    return res;
                });
                return movieResult.Result;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
