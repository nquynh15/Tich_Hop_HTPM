using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TaoWebAPI.Models;

namespace TaoWebAPI.Controllers
{
    public class SanPhamController : ApiController
    {

        CSDLTestEntitiesDB db = new CSDLTestEntitiesDB();

        [HttpGet] /*http://localhost:90/hocrestful23/api/sanpham*/
        public List<SanPham> LySP()
        {
            return db.SanPhams.ToList();
        }
        [HttpGet]
        public List<SanPham> TimSPTheoDanhMuc(int madm)
        {
            return db.SanPhams.Where(x => x.MaDanhMuc == madm).ToList();
        }
        [HttpGet]

        public SanPham TimSPTheoMa(int ma)
        {
            return db.SanPhams.FirstOrDefault(x => x.Ma == ma);
        }
        [HttpPost]
        public bool ThemMoi(int ma, string ten, int gia, int madm)
        {
            SanPham sp = db.SanPhams.FirstOrDefault(x => x.Ma == ma);
            if (sp == null)
            {
                SanPham spm = new SanPham();
                spm.Ma = ma;
                spm.Ten = ten;
                spm.DonGia = gia;
                spm.MaDanhMuc = madm;
                db.SanPhams.Add(spm);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        [HttpPut]
        public bool CapNhat(int ma, string ten, int gia, int madm)
        {
            SanPham sp = db.SanPhams.FirstOrDefault(x => x.Ma == ma);
            if (sp != null)
            {
                sp.Ma = ma;
                sp.Ten = ten;
                sp.DonGia = gia;
                sp.MaDanhMuc = madm;
                db.SaveChanges();
                return true;
            }
            return false;
        }

        [HttpDelete]
        public bool Xoa(int id)
        {
            SanPham sp = db.SanPhams.FirstOrDefault(x => x.Ma == id);
            if (sp != null)
            {
                db.SanPhams.Remove(sp);
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }


}
