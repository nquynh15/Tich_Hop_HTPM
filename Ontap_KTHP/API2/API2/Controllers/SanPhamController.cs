using API2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API2.Controllers
{
    public class SanPhamController : ApiController
    {
        dataSanPhamEntities db = new dataSanPhamEntities();

        [HttpGet]
        public List<SanPham> LaySP()
        {
            return db.SanPhams.ToList();
        }
        [HttpGet]
        public List<SanPham> LaySPTheoDM(int madm)
        {
            return db.SanPhams.Where(x => x.MaDanhMuc == madm).ToList();
        }
        [HttpGet]
        public SanPham LaySPTheoMa(int ma)
        {
            return db.SanPhams.FirstOrDefault(x => x.MaDanhMuc == ma);
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
                SanPham spm = new SanPham();
                spm.Ma = ma;
                spm.Ten = ten;
                spm.DonGia = gia;
                spm.MaDanhMuc = madm;
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
