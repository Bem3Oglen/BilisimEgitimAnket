using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BilisimEgitimAnket.Models
{
    public class Sonuc
    {
        [Key]
        public int ID { get; set; }
        public int TedbirID { get; set; }
        public int UserID { get; set; }
        public int GrupID { get; set; }
        public int CevapID { get; set; }

        [ForeignKey("GrupID")]
        public virtual Kelime Kelimeler { get; set; }
        [ForeignKey("UserID")]
        public virtual Kullanici Kullaniciler { get; set; }
    }
}