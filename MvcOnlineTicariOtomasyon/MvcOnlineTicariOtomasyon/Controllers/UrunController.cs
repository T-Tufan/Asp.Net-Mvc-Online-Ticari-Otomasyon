using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;
namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class UrunController : Controller
    {
        Context db = new Context();
        // GET: Urun
        public ActionResult Index()
        {
            var urunler = db.Uruns.Where(x => x.UrunDurum == true).ToList();
            return View(urunler);
        }
        [HttpGet]
        public ActionResult UrunEkle()
        {
            
            ViewBag.allCategories = KategoriListesi(db);
            return View();
        }
        [HttpPost]
        public ActionResult UrunEkle(Urun u)
        {
            var ktg = db.Kategoris.FirstOrDefault(x => x.KategoriId == u.Kategori.KategoriId);
            u.Kategori = ktg;
            db.Uruns.Add(u);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UrunSil(int id)
        {
            var deleted = db.Uruns.Find(id);
            deleted.UrunDurum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UrunGuncelle(int id)
        {
            var urun = db.Uruns.Find(id);
            ViewBag.kategoriListe = KategoriListesi(db);
            return View(urun);
        }
        [HttpPost]
        public ActionResult UrunGuncelle(Urun urun)
        {
            var urunktg = db.Kategoris.Find(urun.Kategori.KategoriId);
            var updated = db.Uruns.Find(urun.UrunId);

            updated.UrunAd = urun.UrunAd;
            updated.UrunMarka = urun.UrunMarka;
            updated.UrunStok = urun.UrunStok;
            updated.UrunAlisFiyatı = urun.UrunAlisFiyatı;
            updated.UrunSatisFiyatı = urun.UrunSatisFiyatı;
            updated.UrunFotograf = urun.UrunFotograf;
            updated.Kategori = urunktg;

            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IEnumerable<SelectListItem> KategoriListesi(Context db)
        {
            IEnumerable<SelectListItem> ktg = (from k in db.Kategoris.ToList()
                                                       select new SelectListItem
                                                       {
                                                           Text = k.KategoriAd,
                                                           Value = k.KategoriId.ToString()
                                                       }).ToList();
            return ktg;
        }
    }
}