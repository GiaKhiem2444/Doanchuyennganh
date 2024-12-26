using DAN_WEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting;

namespace DAN_WEB.Controllers
{
    public class SinhVienController : Controller
    {
        QLDSVienNhom12Context db = new QLDSVienNhom12Context();
        public IActionResult Index()
        {
            ViewBag.sv = db.SinhViens;
            return View();
        }
        
        [HttpGet]
        public ActionResult them()
        {
            ViewBag.DSLop = new SelectList(db.Lops.ToList(), "Malop", "Tenlop");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult them(SinhVien n)
        {
            SinhVien a = db.SinhViens.Find(n.Masv);
            if (a != null)
            {
                return Content("Mã số học viên này đã có rồi. Ko thêm được.");
            }
            else
            {
                db.SinhViens.Add(n);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }


        [HttpGet]
        public IActionResult sua(string id)
        {
            SinhVien a = db.SinhViens.Find(id);
            if (a == null)
            {
                return Content("Mã số sinh viên này ko tồn tại. Ko sửa được.");
            }
            else
            {
                ViewBag.DSLop = new SelectList(db.Lops.ToList(), "Malop", "Tenlop");
                return View(a);
            }
        }
        [HttpPost]
        public IActionResult sua(SinhVien sv)
        {
            SinhVien a = db.SinhViens.Find(sv.Masv);
            if (a == null)
            {
                return Content("Mã số sinh viên này ko tồn tại. Ko sửa được.");
            }
            else
            {
                a.Hosv = sv.Hosv;
                a.Tensv = sv.Tensv;
                a.Ngaysinh = sv.Ngaysinh;
                a.Gioitinh = sv.Gioitinh;
                a.Diachi = sv.Diachi;
                a.Sdt = sv.Sdt;
                a.Malop = sv.Malop;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }


        [HttpGet]
        public ActionResult xoa(string id)
        {
            var a = db.SinhViens.Where(k => k.Masv == id).ToList().Count;
            if (a <= 0)
                ViewBag.flagDelete = false;
            else
                ViewBag.flagDelete = true;
            SinhVien n = db.SinhViens.Find(id);
            ViewBag.nsx = n;
            return View(n);
        }
        [HttpPost, ActionName("xoa")]
        public ActionResult xoa_Post(string id)
        {
            SinhVien n = db.SinhViens.Find(id);
            if (n != null)
            {
                db.SinhViens.Remove(n);
                db.SaveChanges();
            }
            return RedirectToAction("index");
        }




        public IActionResult xemlop(string id)
        {
            Lop x = db.Lops.Find(id);

            return PartialView(x);
        }
    }
}
