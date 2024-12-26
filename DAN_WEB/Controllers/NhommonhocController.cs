using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using DAN_WEB.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace DAN_WEB.Controllers
{
    public class NhommonhocController : Controller

    {
        QLDSVienNhom12Context db = new QLDSVienNhom12Context();
        public IActionResult Index()
        {
            ViewBag.nmh = db.NhomMonHocs;
            return View();
        }

        [HttpGet]
        public ActionResult Them()
        {
            // Populate dropdown lists for related entities
            ViewBag.DSHK = new SelectList(db.HocKies.ToList(), "Mahk", "Tenhk"); // List of semesters
            ViewBag.DSQT = new SelectList(db.QuanTris.ToList(), "Maqt", "Tenqt"); // List of administrators
            ViewBag.DSMH = new SelectList(db.MonHocs.ToList(), "Mamh", "Tenmh"); // List of subjects

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult them(NhomMonHoc n)
        {
            NhomMonHoc a = db.NhomMonHocs.Find(n.Manmh);

            if (a != null)
            {
                return Content("Mã nhóm môn học này đã có rồi. Ko thêm được.");
            }
            else
            {
                db.NhomMonHocs.Add(n);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        [HttpGet]
        public IActionResult xoa(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhomMonHoc = db.NhomMonHocs.Include(n => n.MahkNavigation)
                                            .Include(n => n.MaqtNavigation)
                                            .Include(n => n.MamhNavigation)
                                            .FirstOrDefault(m => m.Manmh == id);

            if (nhomMonHoc == null)
            {
                return NotFound();
            }

            return View(nhomMonHoc);
        }

        [HttpPost, ActionName("Xoa")]
        [ValidateAntiForgeryToken]
        public IActionResult xoa_Post(string id)
        {
            var nhomMonHoc = db.NhomMonHocs.Find(id);
            if (nhomMonHoc != null)
            {
                db.NhomMonHocs.Remove(nhomMonHoc);
                db.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }




    }
