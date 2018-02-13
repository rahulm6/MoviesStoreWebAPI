using MoviesStore.Service.Common.Entity.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesStore.Service.BL
{
    public interface IMoviesManager
    {
        List<Movie> GetAllMovies();
        Movie AddMovie(Movie movie);

        Movie GetMovieByID(int ID);

        Movie EditMovie(Movie movie);
    }
}
