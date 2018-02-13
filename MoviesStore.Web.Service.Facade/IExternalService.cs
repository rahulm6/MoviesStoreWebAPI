using MoviesStore.Web.Service.Facade.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesStore.Web.Service.Facade
{
    public interface IExternalService
    {
        List<MovieDTO> GetAllMoviesList();
        List<ActorDTO> GetAllActors();
        List<ProducerDTO> GetAllProducers();
        MovieDTO AddMovie(MovieDTO movie);
        MovieDTO EditMovie(MovieDTO movie);

        MovieDTO GetMovieByID(int ID);
        ProducerDTO AddProducer(ProducerDTO producer);

        ActorDTO AddActor(ActorDTO actor);

        List<YearDTO> GetAllYear();
    }


}
