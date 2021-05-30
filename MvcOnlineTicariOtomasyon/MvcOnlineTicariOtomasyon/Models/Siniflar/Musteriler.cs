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
        [StringLength(30)]
        public string MusteriAd { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string MusteriSoyad { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string MusteriSehir { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string MusteriEmail { get; set; }
         
        public ICollection<SatisHareket> SatisHarekets { get; set; }
    }
}