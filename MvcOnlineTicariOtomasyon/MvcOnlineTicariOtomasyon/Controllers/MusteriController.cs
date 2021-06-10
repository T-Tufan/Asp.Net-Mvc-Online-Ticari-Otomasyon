using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;
namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class MusteriController : Controller
    {
        Context db = new Context();
        // GET: Musteri
        public ActionResult Index()
        {
            var musteris = db.Musterilers.Where(x => x.Durum ==true).ToList();
            return View(musteris);
        }
        [HttpGet]
        public ActionResult MusteriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult MusteriEkle(Musteriler m)
        {
            m.Durum = true;
            db.Musterilers.Add(m);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriSil(int id)
        {
            var deleted = db.Musterilers.Find(id);
            deleted.Durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriGuncelle(int id)
        {
            var musteriler = db.Musterilers.Find(id);
            return View(musteriler);
        }
        [HttpPost]
        public ActionResult MusteriGuncelle(Musteriler mus)
        {
            if (!ModelState.IsValid)
            {
                return View("MusteriGuncelle");
            }
            var updateMusteri= db.Musterilers.Find(mus.MusteriId);

            updateMusteri.MusteriAd = mus.MusteriAd;
            updateMusteri.MusteriSoyad = mus.MusteriSoyad;
            updateMusteri.MusteriSehir = mus.MusteriSehir;
            updateMusteri.MusteriEmail = mus.MusteriEmail;

            db.SaveChanges(); 
            return RedirectToAction("Index");
        }
        public ActionResult MusteriDetay(int id)
        {
            var degerler = db.SatisHarekets.Where(x => x.Musteriler.MusteriId == id).ToList();
            var musteriAdSoyad = db.Musterilers.Where(x => x.MusteriId == id).Select(y => y.MusteriAd +" "+y.MusteriSoyad).FirstOrDefault();
            ViewBag.musteriAdSoyad = musteriAdSoyad;
            return View(degerler);
        }
    }
}