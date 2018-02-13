using AutoMapper;
using MoviesStore.Web.Models;
using MoviesStore.Web.Service.Facade;
using MoviesStore.Web.Service.Facade.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoviesStore.Web.Controllers
{
    public class ActorController : Controller
    {
        public ActorController()
        {

        }
        // GET: Actor
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AddActor(ActorViewModel actor)
        {
            ExternalService service = new ExternalService();
            ActorDTO actorDTO = Mapper.Map<ActorDTO>(actor);
            var result = service.AddActor(actorDTO);
            return Json(new { data = result, JsonRequestBehavior.AllowGet });
            //return View();
        }
        public JsonResult GetAllActors()
        {
            ExternalService service = new ExternalService();
            List<ActorDTO> result = service.GetAllActors();
            var data = Mapper.Map<List<ActorViewModel>>(result);
            return Json(data, JsonRequestBehavior.AllowGet);
            //return Json(new { data = data, JsonRequestBehavior.AllowGet });
        }

        /// <summary>
        /// Search data based on search term for Actors
        /// </summary>
        /// <param name="searchTerm"></param>
        /// <returns></returns>
        public JsonResult SearchActors(string searchTerm = "")
        {
            ExternalService service = new ExternalService();
            List<ActorDTO> result = service.GetAllActors();
            var Actors = Mapper.Map<List<ActorViewModel>>(result);
            var data = (from N in Actors
                        where N.Name.StartsWith(searchTerm.ToUpper())
                        select new { N.Name, N.ActorID });
            return Json(data, JsonRequestBehavior.AllowGet);
            //return Json(new { data = data, JsonRequestBehavior.AllowGet });
        }
    }
}