using MoviesStore.Service.Common.Entity.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesStore.Service.DAL.IRepository
{
    public interface IMoviesRepository
    {
        List<Movie> GetAllMovies(string spName, string providerName, string connectionString);
        Movie GetMovieByID(int ID,string spName, string providerName, string connectionString);
        Movie AddMovie(Movie movie,string spName, string providerName, string connectionString);

        Movie EditMovie(Movie movie, string spName, string providerName, string connectionString);
    }
}
