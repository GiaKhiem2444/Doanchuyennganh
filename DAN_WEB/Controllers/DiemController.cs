using DAN_WEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace DAN_WEB.Controllers
{
    public class DiemController : Controller
    {
        QLDSVienNhom12Context db = new QLDSVienNhom12Context();
        public IActionResult Index()
        {
            ViewBag.diem = db.Diems;
            return View();
        }

        [HttpGet]
        public ActionResult them()
        {
            ViewBag.DSSinhVien = new SelectList(db.SinhViens.ToList(), "Masv", "Tensv");
            ViewBag.DSMH = new SelectList(db.MonHocs.ToList(), "Mamh", "Tenmh");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult them(Diem n)
        {
            Diem a = db.Diems.Find(n.Mamh, n.Masv);

            if (a != null)
            {
                return Content("Mã số sinh viên và mã môn học này đã có rồi. Ko thêm được.");
            }
            else
            {
                db.Diems.Add(n);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        [HttpGet]
        public IActionResult sua(string Masv, string Mamh)
        {
            
            var diem = db.Diems.FirstOrDefault(d => d.Masv == Masv && d.Mamh == Mamh);
            if (diem == null)
            {
                return Content("Không tìm thấy bản ghi.");
            }

            // Truyền dữ liệu sang view
            return View(diem);
        }

        [HttpPost]
        public IActionResult Sua(Diem diem)
        {
            var a = db.Diems.FirstOrDefault(d => d.Masv == diem.Masv && d.Mamh == diem.Mamh);
            if (a == null)
            {
                return Content("Mã số sinh viên hoặc môn học này không tồn tại. Không sửa được.");
            }

            // Cập nhật dữ liệu
            a.Diemgk = diem.Diemgk;
            a.Diemck = diem.Diemck;
            a.Hocky = diem.Hocky;
            db.SaveChanges();

            return RedirectToAction("Index");
        }





        public IActionResult xemsv(string id)
        {
            SinhVien x = db.SinhViens.Find(id);

            return PartialView(x);
        }
        public IActionResult xemmh(string id)
        {
            MonHoc x = db.MonHocs.Find(id);

            return PartialView(x);
        }
        [HttpGet]
        public ActionResult xoa(string masv, string mamh)
        {
            
            var a = db.Diems.Where(d => d.Masv == masv && d.Mamh == mamh).ToList().Count;

            ViewBag.flagDelete = a > 0;

           
            Diem n = db.Diems.FirstOrDefault(d => d.Masv == masv && d.Mamh == mamh);

            ViewBag.diem = n;

            return View(n);
        }


        [HttpPost, ActionName("xoa")]
        public ActionResult xoa_Post(string masv, string mamh)
        {

            Diem n = db.Diems.FirstOrDefault(d => d.Masv == masv && d.Mamh == mamh);

            if (n != null)
            {

                db.Diems.Remove(n);
                db.SaveChanges();
            }


            return RedirectToAction("Index");
        }

    }
}
