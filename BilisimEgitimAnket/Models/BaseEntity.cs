using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BilisimEgitimAnket.Models
{
    public class BaseEntity
    {
        public int ID { get; set; }

        [DisplayName("Oluşturma Tarihi")]
        [DataType(DataType.Date)]
        public DateTime OTAR { get; set; }
        [DisplayName("Güncelleme Tarihi")]
        [DataType(DataType.Date)]
        public DateTime GTAR { get; set; }

    }
}