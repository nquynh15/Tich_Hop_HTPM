using ONTAP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ONTAP.Controllers
{
    public class DanhMucController : ApiController
    {
        dataSanPhamEntities db = new dataSanPhamEntities();
        [HttpGet]
        public List<DanhMuc> LayDM()
        {
            return db.DanhMucs.ToList();
        }
    }
}
