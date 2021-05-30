using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class SatisHareket
    {
        [Key]
        public int SatisId { get; set; }
        //Ürün
        public Urun Urun { get; set; }
        //Müşteri
        public Musteriler Musteriler { get; set; }
        //Personel
        public Personel Personel { get; set; }
        public DateTime SatisTarih { get; set; }
        public int Adet { get; set; }
        public decimal Fiyat { get; set; }
        public decimal ToplamTutar { get; set; }
    }
}