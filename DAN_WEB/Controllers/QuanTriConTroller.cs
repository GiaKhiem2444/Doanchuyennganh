using DAN_WEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DAN_WEB.Controllers
{

    public class QuanTriConTroller : Controller
    {
        QLDSVienNhom12Context db = new QLDSVienNhom12Context();
        public IActionResult Index()
        {
            ViewBag.qt = db.QuanTris;
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
        public ActionResult them(QuanTri n)
        {
            QuanTri a = db.QuanTris.Find(n.Maqt);
            if (a != null)
            {
                return Content("Mã số quản trị này đã có rồi. Ko thêm được.");
            }
            else
            {
                db.QuanTris.Add(n);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public IActionResult sua(string id)
        {
            QuanTri a = db.QuanTris.Find(id);
            if (a == null)
            {
                return Content("Mã số quản trị này ko tồn tại. Ko sửa được.");
            }
            else
            {
                ViewBag.DSLop = new SelectList(db.Lops.ToList(), "Malop", "Tenlop");
                return View(a);
            }
        }
        [HttpPost]
        public IActionResult sua(QuanTri qt)
        {
            QuanTri a = db.QuanTris.Find(qt.Maqt);
            if (a == null)
            {
                return Content("Mã số quản trị này ko tồn tại. Ko sửa được.");
            }
            else
            {
                a.Tenqt = qt.Tenqt;
                a.Sdt = qt.Sdt;
                a.Diachi = qt.Diachi;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }


        [HttpGet]
        public ActionResult xoa(string id)
        {
            var a = db.QuanTris.Where(k => k.Maqt == id).ToList().Count;
            if (a <= 0)
                ViewBag.flagDelete = false;
            else
                ViewBag.flagDelete = true;
            QuanTri n = db.QuanTris.Find(id);
            ViewBag.qt = n;
            return View(n);
        }
        [HttpPost, ActionName("xoa")]
        public ActionResult xoa_Post(string id)
        {
            QuanTri n = db.QuanTris.Find(id);
            if (n != null)
            {
                db.QuanTris.Remove(n);
                db.SaveChanges();
            }
            return RedirectToAction("index");
        }

    }
}
