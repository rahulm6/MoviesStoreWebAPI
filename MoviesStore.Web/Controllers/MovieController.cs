using AutoMapper;
using MoviesStore.Web.Models;
using MoviesStore.Web.Service.Facade;
using MoviesStore.Web.Service.Facade.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoviesStore.Web.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAllMovies()
        {
            ExternalService service = new ExternalService();
            List<MovieDTO> result = service.GetAllMoviesList();
            var data = Mapper.Map<List<MovieViewModel>>(result);
            return View(data);
        }

        [HttpGet]
        public ActionResult AddMovie()
        {
            return View();
        }


        [HttpGet]
        public ActionResult CreateMovie()
        {
            //ExternalService service = new ExternalService();
            //List<MovieDTO> result = service.GetAllMoviesList();
            return View();
        }

        /// <summary>
        /// Get the Movie Data by ID for Edit
        /// </summary>
        /// <param name="movieID"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult EditMovie(int movieID)
        {
            ExternalService service = new ExternalService();
            MovieDTO result = service.GetMovieByID(movieID);
            MovieViewModel movie = Mapper.Map<MovieViewModel>(result);
            ViewData["counter"] = movie.Actors.Count; ;
            return View(movie);
        }


        /// <summary>
        /// Add a new Movie
        /// </summary>
        /// <param name="movie"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CreateMovie(MovieViewModel movie)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (movie.File != null)
            {
                string pic = System.IO.Path.GetFileName(movie.File.FileName);
                string path = System.IO.Path.Combine(
                                       Server.MapPath("~/Assets/Images"), pic);
                // file is uploaded
                movie.File.SaveAs(path);
                movie.Poster = "/Assets/Images/" + pic;


            }
            ExternalService service = new ExternalService();
            var movieDTO = Mapper.Map<MovieDTO>(movie);
            var result = service.AddMovie(movieDTO);
            return RedirectToAction("GetAllMovies");
        }

        /// <summary>
        /// Edit a Movie
        /// </summary>
        /// <param name="movie"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EditMovie(MovieViewModel movie)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (movie.File != null)
            {
                string pic = System.IO.Path.GetFileName(movie.File.FileName);
                string path = System.IO.Path.Combine(
                                       Server.MapPath("~/Assets/Images"), pic);
                // file is uploaded
                movie.File.SaveAs(path);
                movie.Poster = "/Assets/Images/" + pic;


            }
           
            ExternalService service = new ExternalService();
            var movieDTO = Mapper.Map<MovieDTO>(movie);
            var result = service.EditMovie(movieDTO);
            
            return RedirectToAction("GetAllMovies");
        }


        [HttpPost]
        public ActionResult AddMovie(MovieViewModel movie)
        {
            
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (movie.File != null)
            {
                string pic = System.IO.Path.GetFileName(movie.File.FileName);
                string path = System.IO.Path.Combine(
                                       Server.MapPath("~/Assets/Images"), pic);
                // file is uploaded
                movie.File.SaveAs(path);
                movie.Poster = "/Assets/Images" + pic;
                

            }
            ExternalService service = new ExternalService();
            var movieDTO = Mapper.Map<MovieDTO>(movie);
            var result = service.AddMovie(movieDTO);
            return View();
        }
    }
}