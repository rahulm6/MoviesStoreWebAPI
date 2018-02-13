using MoviesStore.Service.BL;
using MoviesStore.Service.Common.Entity.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MoviesStore.Service.WebAPI.Controllers
{
    public class MovieController : ApiController
    {
        private readonly IMoviesManager _MoviesManager = null;
       
        #region Constructor initialization

        public MovieController(IMoviesManager _MoviesManager)
        {
            this._MoviesManager = _MoviesManager;
        }

        #endregion

        /// <summary>
        /// Get All Movie List
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetAllMovies()
        {
            var result = _MoviesManager.GetAllMovies();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        /// <summary>
        /// Get A Movie Details by ID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetMovieByID(int ID)
        {
            var result = _MoviesManager.GetMovieByID(ID);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        /// <summary>
        /// Add a New Movie
        /// </summary>
        /// <param name="movie"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage AddMovie(Movie movie)
        {
            var result = _MoviesManager.AddMovie(movie);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="movie"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage EditMovie(Movie movie)
        {
            var result = _MoviesManager.EditMovie(movie);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}
