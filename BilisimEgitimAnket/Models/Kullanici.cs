using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BilisimEgitimAnket.Models
{
    public class Kullanici:BaseEntity
    {
        [DisplayName("Ad Soyad :")]
        [StringLength(100)]
        [Required(ErrorMessage = "Bu alan girişi zorunludur.")]
        public string KADI { get; set; }
        [DisplayName("E-Posta :")]
        [StringLength(50)]
        [Required(ErrorMessage = "E-Posta bilgisi zorunludur.")]
        [DataType(DataType.EmailAddress)]
        public string EMAIL { get; set; }

        public int FID { get; set; }

        [ForeignKey("FID")]
        public virtual Firma Firmalar { get; set; }
        public virtual ICollection<Sonuc> Sonuclar { get; set; }
    }
}