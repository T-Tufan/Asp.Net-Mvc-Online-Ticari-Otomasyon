using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;
namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class DepartmanController : Controller
    {
        Context db = new Context();
        // GET: Departman
        public ActionResult Index()
        {
            var departmans = db.Departmans.Where(x => x.Durum == true).ToList();
            return View(departmans);
        }
        [HttpGet]
        public ActionResult DepartmanEkle()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DepartmanSil(int id)
        {
            var deleted = db.Departmans.Find(id);
            deleted.Durum = false;
            db.SaveChanges();   
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult DepartmanEkle(Departman d)
        {
            db.Departmans.Add(d);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult DepartmanDetay(int id)
        {
            var departmanbilgi = db.Departmans.Find(id);
            var personeller = db.Personels.Where(x => x.Departman.DepartmentId == id).ToList();
            personeller[0].Departman = departmanbilgi;
            return View(personeller);
        }
    }
}