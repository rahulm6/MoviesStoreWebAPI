using MoviesStore.Service.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MoviesStore.Service.WebAPI.Controllers
{
    public class MasterDataController : ApiController
    {
        private readonly IMasterDataManager _masterDataManager = null;

        #region Constructor initialization

        public MasterDataController(IMasterDataManager _masterDataManager)
        {
            this._masterDataManager = _masterDataManager;
        }

        #endregion

        [HttpGet]
        public HttpResponseMessage GetAllYears()
        {
            var result = _masterDataManager.GetAllYears();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}
