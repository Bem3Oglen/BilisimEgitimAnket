using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BilisimEgitimAnket.Models
{
    public class Firma:BaseEntity
    {
        [DisplayName("Firma Adı :")]
        [StringLength(150)]
        [Required(ErrorMessage = "Bu alan girişi zorunludur.")]
        public string FADI { get; set; }

        [DisplayName("Adres :")]
        [StringLength(350)]
        [DataType(DataType.MultilineText)]
        public string FADRES { get; set; }

        [DisplayName("Yetkili Adı :")]
        [StringLength(100)]
        [Required(ErrorMessage = "Bu alan girişi zorunludur.")]
        public string YETKILI { get; set; }

        [DisplayName("Telefon :")]
        [StringLength(20)]
        public string TEL1 { get; set; }

        [DisplayName("Telefon :")]
        [StringLength(20)]
        public string TEL2 { get; set; }

        [DisplayName("GSM :")]
        [StringLength(20)]
        public string GSM { get; set; }

        [DisplayName("Faks :")]
        [StringLength(20)]
        public string FAKS { get; set; }

        [DisplayName("E-Posta :")]
        [StringLength(50)]
        [Required(ErrorMessage = "E-Posta bilgisi zorunludur.")]
        [DataType(DataType.EmailAddress)]
        public string EMAIL { get; set; }

        [DisplayName("Açıklama :")]
        [StringLength(450)]
        [DataType(DataType.MultilineText)]
        public string ACIKLAMA { get; set; }

        public virtual ICollection<Kullanici> Kullaniciler { get; set; }
    }
}