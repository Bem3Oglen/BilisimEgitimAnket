using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BilisimEgitimAnket.Models
{
    public class Kelime:BaseEntity
    {
        [DisplayName("Grup ID")]
        [Index(IsUnique = true)]
        public int GID { get; set; }
        [DisplayName("Sarı Grup")]
        [Required(ErrorMessage = "Girilmesi zorunlu alan.")]
        [StringLength(50)]
        public string SARI { get; set; }
        [DisplayName("Kırmızı Grup")]
        [Required(ErrorMessage = "Girilmesi zorunlu alan.")]
        [StringLength(50)]
        public string KIRMIZI { get; set; }
        [DisplayName("Mavi Grup")]
        [Required(ErrorMessage = "Girilmesi zorunlu alan.")]
        [StringLength(50)]
        public string MAVI { get; set; }
        [DisplayName("Yeşil Grup")]
        [Required(ErrorMessage = "Girilmesi zorunlu alan.")]
        [StringLength(50)]
        public string YESIL { get; set; }
        [DisplayName("Pozitif")]
        public bool DURUM { get; set; }

        public virtual ICollection<SARI> Sarilar { get; set; }
        public virtual ICollection<MAVI> Maviler { get; set; }
        public virtual ICollection<KIRMIZI> Kirmiziler { get; set; }
        public virtual ICollection<YESIL> Yesiller { get; set; }
        public virtual ICollection<Sonuc> Sonuclar { get; set; }
    }
}