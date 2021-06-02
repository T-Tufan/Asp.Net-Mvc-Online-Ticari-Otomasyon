using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;
namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class KategoriController : Controller
    {
        Context db = new Context();
        // GET: Kategori
        public ActionResult Index()
        {
            var kategoriler = db.Kategoris.ToList();
            return View(kategoriler);
        }
        [HttpGet]
        public ActionResult KategoriEkle()
        {
           return View();
        }
        [HttpPost]
        public ActionResult KategoriEkle(Kategori k)
        {
            db.Kategoris.Add(k);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult KategoriSil(int id)
        {
            var deleted = db.Kategoris.Find(id);
            db.Kategoris.Remove(deleted);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult KategoriGuncelle(int id)
        {
            var updated = db.Kategoris.Find(id);
            return View(updated);
        }
        [HttpPost]
        public ActionResult KategoriGuncelle(Kategori k)
        {
            var updated = db.Kategoris.Find(k.KategoriId);
            updated.KategoriAd = k.KategoriAd;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}