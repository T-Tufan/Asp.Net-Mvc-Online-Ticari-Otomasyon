using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Urun
    {
        [Key]
        public int UrunId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string UrunAd { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string UrunMarka { get; set; }

        public short UrunStok { get; set; }
        public decimal UrunAlisFiyatı { get; set; }
        public decimal UrunSatisFiyatı { get; set; }
        //Kategori 
        public virtual Kategori Kategori { get; set; }
        public bool UrunDurum { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string UrunFotograf { get; set; }
        //SatisHareket
        public ICollection<SatisHareket> SatisHarekets { get; set; }
    }
}