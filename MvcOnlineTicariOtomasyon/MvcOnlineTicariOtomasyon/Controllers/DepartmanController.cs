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
            var departmanAd = db.Departmans.Where(x => x.DepartmentId == id).Select(y => y.DepartmentAd).FirstOrDefault();
            ViewBag.depAd = departmanAd;
            return View(personeller);
        }
        public ActionResult DepartmanGuncelle(int id)
        {
            var departman = db.Departmans.Find(id);
            return View(departman);
        }
        [HttpPost]
        public ActionResult DepartmanGuncelle(Departman dep)
        {
            var updateDepartman = db.Departmans.Find(dep.DepartmentId);
            updateDepartman.DepartmentAd = dep.DepartmentAd;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanPersonelSatisBilgi(int id)
        {
            var satislar = db.SatisHarekets.Where(x => x.Personel.PersonelId == id).ToList();
            var personelAd = db.Personels.Where(x => x.PersonelId == id).Select(y => y.PersonelAd + " " + y.PersonelSoyad).FirstOrDefault();
            ViewBag.personelAd = personelAd;
            return View(satislar);
        }
    }
}