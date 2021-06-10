using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Musteriler
    {
        [Key]
        public int MusteriId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30,ErrorMessage ="İsim alanı en fazla 30 karakter olabilir!")]
        [Required(ErrorMessage = "Bu alan boş geçilemez!")]
        public string MusteriAd { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "Soyad alanı en fazla 30 karakter olabilir!")]
        [Required(ErrorMessage ="Bu alan boş geçilemez!")]
        public string MusteriSoyad { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(20, ErrorMessage = "Şehir alanı en fazla 20 karakter olabilir!")]
        [Required(ErrorMessage = "Bu alan boş geçilemez!")]
        public string MusteriSehir { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50, ErrorMessage = "E-Mail alanı en fazla 50 karakter olabilir!")]
        [EmailAddress(ErrorMessage ="Geçersiz E-Mail Adresi!")]
        [Required(ErrorMessage = "Bu alan boş geçilemez!")]
        public string MusteriEmail { get; set; }

        public bool Durum { get; set; }
        public ICollection<SatisHareket> SatisHarekets { get; set; }
    }
}