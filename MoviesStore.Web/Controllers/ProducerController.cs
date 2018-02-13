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
    public class ProducerController : Controller
    {
        // GET: Producer
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddProducer()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AddProducer(ProducerViewModel producer)
        {
            ExternalService service = new ExternalService();
            ProducerDTO producerDTO = Mapper.Map<ProducerDTO>(producer);
            var result = service.AddProducer(producerDTO);
            return Json(new { data= result, JsonRequestBehavior.AllowGet});
            //return View();
        }
       

        /// <summary>
        /// Search data based on search term for Producers
        /// </summary>
        /// <param name="searchTerm"></param>
        /// <returns></returns>
        public JsonResult SearchProducers(string searchTerm="")
        {
            ExternalService service = new ExternalService();
            List<ProducerDTO> result = service.GetAllProducers();
            var Producers = Mapper.Map<List<ProducerViewModel>>(result);
            var data = (from N in Producers
                        where N.Name.StartsWith(searchTerm.ToUpper())
                        select new { N.Name, N.ProducerID });
            return Json(data, JsonRequestBehavior.AllowGet);
            //return Json(new { data = data, JsonRequestBehavior.AllowGet });
        }
    }
}