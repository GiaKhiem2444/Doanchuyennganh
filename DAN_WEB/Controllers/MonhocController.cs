using DAN_WEB.Models;
using Microsoft.AspNetCore.Mvc;

namespace DAN_WEB.Controllers
{
    public class MonhocController : Controller
    {
        QLDSVienNhom12Context db = new QLDSVienNhom12Context();
        public IActionResult Index()
        {
            ViewBag.monhoc = db.MonHocs;
            return View();
        }
        public ActionResult them()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult them(MonHoc n)
        {
            MonHoc a = db.MonHocs.Find(n.Mamh);
            if (a != null)
            {
                return Content("Mã môn học này đã có rồi. Ko thêm được.");
            }
            else
            {
                db.MonHocs.Add(n);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        [HttpGet]
        public IActionResult sua(string id)
        {
            MonHoc a = db.MonHocs.Find(id);
            if (a == null)
            {
                return Content("Mã môn học này ko tồn tại. Ko sửa được.");
            }
            else
            {

                return View(a);
            }
        }
        [HttpPost]
        public IActionResult sua(MonHoc mh)
        {
            MonHoc a = db.MonHocs.Find(mh.Mamh);
            if (a == null)
            {
                return Content("Mã môn học này ko tồn tại. Ko sửa được.");
            }
            else
            {
                a.Mamh = mh.Mamh;
                a.Tenmh = mh.Tenmh;
                a.Stc = mh.Stc;

                db.SaveChanges();
                return RedirectToAction("Index");
            }

        }
        [HttpGet]
        public ActionResult xoa(string id)
        {
            var a = db.MonHocs.Where(k => k.Mamh == id).ToList().Count;
            if (a <= 0)
                ViewBag.flagDelete = false;
            else
                ViewBag.flagDelete = true;
            MonHoc n = db.MonHocs.Find(id);
            ViewBag.monhoc = n;
            return View(n);
        }
        [HttpPost, ActionName("xoa")]
        public ActionResult xoa_Post(string id)
        {
            MonHoc n = db.MonHocs.Find(id);
            if (n != null)
            {
                db.MonHocs.Remove(n);
                db.SaveChanges();
            }
            return RedirectToAction("index");
        }

    }
}
