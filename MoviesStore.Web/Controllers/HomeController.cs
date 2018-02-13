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
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        /// <summary>
        /// Get Year by Search hint
        /// </summary>
        /// <param name="searchTerm"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetAllYears(string searchTerm = "")
        {
            ExternalService service = new ExternalService();
            List<YearDTO> result = service.GetAllYear();
            var Years = Mapper.Map<List<YearViewModel>>(result);
            var data = (from N in Years
                        where N.Value.StartsWith(searchTerm.ToUpper())
                        select new { N.Value, N.YearID }).Take(50);
            return Json(data, JsonRequestBehavior.AllowGet);
            //return Json(new { data = data, JsonRequestBehavior.AllowGet });
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        
    }
}