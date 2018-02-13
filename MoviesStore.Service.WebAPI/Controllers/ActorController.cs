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
    public class ActorController : ApiController
    {
        private readonly IActorManager _ActorManager = null;

        #region Constructor initialization

        public ActorController(IActorManager _ActorManager)
        {
            this._ActorManager = _ActorManager;
        }

        #endregion

        [HttpGet]
        public HttpResponseMessage GetAllActors()
        {
            var result = _ActorManager.GetAllActors();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        public HttpResponseMessage AddActor(Actor actor)
        {
            var result = _ActorManager.AddActor(actor);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}
