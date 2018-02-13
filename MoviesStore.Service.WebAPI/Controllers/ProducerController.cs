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
    public class ProducerController : ApiController
    {
        private readonly IProducerManager _ProducerManager = null;

        #region Constructor initialization

        public ProducerController(IProducerManager _ProducerManager)
        {
            this._ProducerManager = _ProducerManager;
        }

        #endregion

        [HttpGet]
        public HttpResponseMessage GetAllProducers()
        {
            var result = _ProducerManager.GetAllProducers();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        public HttpResponseMessage AddProducer(Producer producer)
        {
            var result = _ProducerManager.AddProducer(producer);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}
