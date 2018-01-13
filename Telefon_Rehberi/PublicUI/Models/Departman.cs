using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PublicUI.Models
{
    public class Departman
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Bu alan boş geçilemez.")]
        [DisplayName("Departman Adı")]
        public string Adi { get; set; }
        public virtual ICollection<Calisan> Calisanlar { get; set; }
    }
}