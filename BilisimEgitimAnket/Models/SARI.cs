using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BilisimEgitimAnket.Models
{
    public class SARI:BaseEntity
    {
        public int GID { get; set; }
        [DisplayName("Sözcük")]
        [StringLength(50)]
        public string SOZCUK { get; set; }
        [DisplayName("Cümle - 1")]
        [Required(ErrorMessage = "Girilmesi zorunlu alan.")]
        [StringLength(500)]
        [DataType(DataType.MultilineText)]
        public string CUMLE1 { get; set; }
        [DisplayName("Cümle - 2")]
        [Required(ErrorMessage = "Girilmesi zorunlu alan.")]
        [StringLength(500)]
        [DataType(DataType.MultilineText)]
        public string CUMLE2 { get; set; }
        [DisplayName("Cümle - 3")]
        [Required(ErrorMessage = "Girilmesi zorunlu alan.")]
        [StringLength(500)]
        [DataType(DataType.MultilineText)]
        public string CUMLE3 { get; set; }
        [ForeignKey("GID")]
        public virtual Kelime Kelime { get; set; }
    }
}