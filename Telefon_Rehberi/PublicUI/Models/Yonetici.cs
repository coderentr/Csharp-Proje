using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PublicUI.Models
{
    public class Yonetici
    {
        [Key]
        public int YoneticiID { get; set; }
        [Required(ErrorMessage = "Bu Alan Boş Geçilemez")]
        [DisplayName("Adı Soyadı")]
        public string AdSoyad { get; set; }

        public virtual ICollection<Calisan> Calisanlar { get; set; }
    }
}