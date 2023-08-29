using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TaoWebAPI.Models;

namespace TaoWebAPI.Controllers
{
    public class DanhMucController : ApiController
    {
        CSDLTestEntitiesDB db = new CSDLTestEntitiesDB();

        [HttpGet]
        public List<DanhMuc> LayDM()
        {
            return db.DanhMucs.ToList();
        }

    }
}
