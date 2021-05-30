using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Faturalar
    {
        [Key]
        public int FaturaId { get; set; }

        [Column(TypeName = "Char")]
        [StringLength(1)]
        public char FaturaSeriNo { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(6)]
        public string FaturaSiraNo { get; set; }
        public DateTime FaturaTarih { get; set; }
        //faturakalem
        public ICollection<FaturaKalem> FaturaKalems { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string FaturaVergiDairesi { get; set; }
        public DateTime FaturaSaat { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string FaturaTeslimEden { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string FaturaTeslimAlan { get; set; }
    }
}