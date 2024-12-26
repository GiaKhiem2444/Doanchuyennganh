using DAN_WEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DAN_WEB.Controllers
{
    public class LopController : Controller
    {
        QLDSVienNhom12Context db = new QLDSVienNhom12Context();
        public IActionResult Index()
        {
            ViewBag.lop = db.Lops;
            return View();
        }

        [HttpGet]
        public ActionResult them()
        {
            
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult them(Lop n)
        {
            Lop a = db.Lops.Find(n.Malop);
            if (a != null)
            {
                return Content("Mã lớp này đã có rồi. Ko thêm được.");
            }
            else
            {
                db.Lops.Add(n);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public IActionResult sua(string id)
        {
            Lop a = db.Lops.Find(id);
            if (a == null)
            {
                return Content("Mã lớp này ko tồn tại. Ko sửa được.");
            }
            else
            {
                
                return View(a);
            }
        }
        [HttpPost]
        public IActionResult sua(Lop lop)
        {
            Lop a = db.Lops.Find(lop.Malop);
            if (a == null)
            {
                return Content("Mã lớp này ko tồn tại. Ko sửa được.");
            }
            else
            {
                a.Tenlop = lop.Tenlop;
                
                db.SaveChanges();
                return RedirectToAction("Index");
            }

        }

        [HttpGet]
        public ActionResult xoa(string id)
        {
            var a = db.Lops.Where(k => k.Malop == id).ToList().Count;
            if (a <= 0)
                ViewBag.flagDelete = false;
            else
                ViewBag.flagDelete = true;
            Lop n = db.Lops.Find(id);
            ViewBag.lop = n;
            return View(n);
        }
        [HttpPost, ActionName("xoa")]
        public ActionResult xoa_Post(string id)
        {
            Lop n = db.Lops.Find(id);
            if (n != null)
            {
                db.Lops.Remove(n);
                db.SaveChanges();
            }
            return RedirectToAction("index");
        }

    }
}
